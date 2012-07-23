function RateMyAmenity() { }

RateMyAmenity.dragShape = null;
RateMyAmenity.dragPixel = null;
RateMyAmenity.MapDivId = 'theMap';
RateMyAmenity._map = null;
RateMyAmenity._points = [];
RateMyAmenity._shapes = [];
RateMyAmenity.ipInfoDbKey = '';

RateMyAmenity.LoadMap = function (latitude, longitude, onMapLoaded) {
    RateMyAmenity._map = new VEMap(RateMyAmenity.MapDivId);

    var options = new VEMapOptions();

    options.EnableBirdseye = false

    this._map.SetDashboardSize(VEDashboardSize.Small);

    if (onMapLoaded != null)
        RateMyAmenity._map.onLoadMap = onMapLoaded;

    if (latitude != null && longitude != null) {
        var center = new VELatLong(latitude, longitude);
    }

    /*new VELatLong sets up the map initially with */
    RateMyAmenity._map.LoadMap(new VELatLong(53.372140913118045, -6.2782144546508905), null, null, null, null, options);
    RateMyAmenity._map.LoadMap(center, 8, null, null, null, null, null, options);
  
}

RateMyAmenity.EnableMapMouseClickCallback = function () {
    RateMyAmenity._map.AttachEvent("onmousedown", RateMyAmenity.onMouseDown);
    RateMyAmenity._map.AttachEvent("onmouseup", RateMyAmenity.onMouseUp);
    RateMyAmenity._map.AttachEvent("onmousemove", RateMyAmenity.onMouseMove);
}

RateMyAmenity.onMouseDown = function (e) {
    if (e.elementID != null) {
        RateMyAmenity.dragShape = RateMyAmenity._map.GetShapeByID(e.elementID);
        return true;
    }
}

RateMyAmenity.onMouseUp = function (e) {
    if (RateMyAmenity.dragShape != null) {
        var x = e.mapX;
        var y = e.mapY;
        RateMyAmenity.dragPixel = new VEPixel(x, y);
        var LatLong = RateMyAmenity._map.PixelToLatLong(RateMyAmenity.dragPixel);
        $("#Latitude").val(LatLong.Latitude.toString());
        $("#Longitude").val(LatLong.Longitude.toString());
        RateMyAmenity.dragShape = null;

        RateMyAmenity._map.FindLocations(LatLong, RateMyAmenity.getLocationResults);
    }
}

RateMyAmenity.onMouseMove = function (e) {
    if (RateMyAmenity.dragShape != null) {
        var x = e.mapX;
        var y = e.mapY;
        RateMyAmenity.dragPixel = new VEPixel(x, y);
        var LatLong = RateMyAmenity._map.PixelToLatLong(RateMyAmenity.dragPixel);
        RateMyAmenity.dragShape.SetPoints(LatLong);
        return true;
    }
}

RateMyAmenity.onEndDrag = function (e) {
    $("#Latitude").val(e.LatLong.Latitude.toString());
    $("#Longitude").val(e.LatLong.Longitude.toString());
}

RateMyAmenity.ClearMap = function () {
    if (RateMyAmenity._map != null) {
        RateMyAmenity._map.Clear();
    }
    RateMyAmenity._points = [];
    RateMyAmenity._shapes = [];
}

RateMyAmenity.LoadPin = function (LL, name, description, draggable) {
    if (LL.Latitude == 0 || LL.Longitude == 0) {
        return;
    }

    var shape = new VEShape(VEShapeType.Pushpin, LL);

    if (draggable == true) {
        shape.Draggable = true;
        shape.onenddrag = RateMyAmenity.onEndDrag;
    }

    //Make a Pushpin with a title and description
    shape.SetTitle("<span class=\"pinTitle\"> " + escape(description) + "</span>");

    if (description !== undefined) {
        shape.SetDescription("<p class=\"pinDetails\">" + escape(name) + "</p>");
    }

    RateMyAmenity._map.AddShape(shape);
    RateMyAmenity._points.push(LL);
    RateMyAmenity._shapes.push(shape);
}

RateMyAmenity.FindAddressOnMap = function (where) {
    var numberOfResults = 1;
    var setBestMapView = true;
    var showResults = true;
    var defaultDisambiguation = true;

    RateMyAmenity._map.Find("", where, null, null, null,
                         numberOfResults, showResults, true, defaultDisambiguation,
                         setBestMapView, RateMyAmenity._callbackForLocation);
}

RateMyAmenity._callbackForLocation = function (layer, resultsArray, places, hasMore, VEErrorMessage) {
    RateMyAmenity.ClearMap();

    if (places == null) {
        RateMyAmenity._map.ShowMessage(VEErrorMessage);
        return;
    }

    //Make a pushpin for each place we find
    $.each(places, function (name, item) {
        var description = "";
        if (item.Description !== undefined) {
            description = item.Description;
        }
        var LL = new VELatLong(item.LatLong.Latitude,
                        item.LatLong.Longitude);

        RateMyAmenity.LoadPin(LL, item.Name, description, true);
    });

    //Make sure all pushpins are visible
    if (RateMyAmenity._points.length > 1) {
        RateMyAmenity._map.SetMapView(RateMyAmenity._points);
    }

    //If we've found exactly one place, that's our address.
    //lat/long precision was getting lost here with toLocaleString, changed to toString
    if (RateMyAmenity._points.length === 1) {
        $("#Latitude").val(RateMyAmenity._points[0].Latitude.toString());
        $("#Longitude").val(RateMyAmenity._points[0].Longitude.toString());
    }
}



RateMyAmenity._renderAmenities = function (amenities) {

    RateMyAmenity.ClearMap();

    $.each(amenities, function (i, amenity) {

        var LL = new VELatLong(amenity.Latitude, amenity.Longitude, 0, null);

        // Add Pin to Map
        RateMyAmenity.LoadPin(LL, amenity.Name, amenity.Description, amenity.Phone, false);


    });

    // Adjust zoom to display all the pins.
    if (RateMyAmenity._points.length > 1) {
        RateMyAmenity._map.SetMapView(RateMyAmenity._points);
    }

    // Display the event's pin-bubble on hover.
    $(".AmenitiesItem").each(function (i, Amenities) {
        $(Amenities).hover(
            function () { RateMyAmenity._map.ShowInfoBox(RateMyAmenity._shapes[i]); },
            function () { RateMyAmenity._map.HideInfoBox(RateMyAmenity._shapes[i]); }
        );
    });

}

RateMyAmenity.FindAddress = function (where) {
    var numberOfResults = 1;
    var setBestMapView = true;
    var showResults = true;
    var defaultDisambiguation = true;

    RateMyAmenity._map.Find("", where, null, null, null,
                         numberOfResults, showResults, true, defaultDisambiguation,
                         setBestMapView, RateMyAmenity._callbackUpdateMapAmenities);

}

RateMyAmenity._callbackUpdateMapAmenities = function (layer, resultsArray, places, hasMore, VEErrorMessage) {

    var center = RateMyAmenity._map.GetCenter();

    $.post("/Search/SearchByLocation",
           { latitude: center.Latitude, longitude: center.Longitude },
           RateMyAmenity._renderAmenities,
           "json");
}