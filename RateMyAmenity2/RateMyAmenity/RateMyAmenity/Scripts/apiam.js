$(document).ready(function () {

    // Send an AJAX request to optain AmenityID Name of Amenity , Comments + Ratings.

    $.getJSON("/api/RateAPI",
            function (data) {

                // On success, 'data' contains a list of Amenities.

                $.each(data, function (key, val) {

                    // Format the text to display not above information

                    var str = val.AmenityID + ':Venue Name' + val.Name + '___Reviews___' + val.Comments + '__Ratings (1-6)__ ' + val.RatingID;

                    // Add a list item for the Amenity

                    $('<li/>', { html: str }).appendTo($('#RateAPIs'));
                });
            });
});

// Search action to find Amenities and details by entering the AmenityID

function find() {

    var id = $('#AmenityID').val();
    $.getJSON("/api/RateAPI/" + id,
                function (data) {
                    var str = data.AmenityID + ':Venue Name' + data.Name + '____Venue' + data.Comments + '____RATING:' + data.RatingID;
                    $('#RateAPI').html(str);
                })
            .fail(
                function (jqXHR, textStatus, err) {
                    $('#RateAPI').html('Error: ' + err);
                });
}     