$(document).ready(function () {

    // Send an AJAX request to optain AmenityID Name of Amenity , Comments + Ratings.

    $.getJSON("/api/RateAPI",
            function (data) {

                // On success, 'data' contains a list of Amenities.

                $.each(data, function (key, val) {

                    // Format the text to display not above information

                    var str = 'Amenity ID: ' + val.AmenityID + ',  Rated Value: ' + val.RatingValue + ',   Comments: ' + val.Comments + ',   Rating ID: ' + val.RatingID;

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
                    var str = 'Amenity ID: ' + data.AmenityID + ',   Rated Value: ' + data.RatingValue + ',   Comments: ' + data.Comments + ',   Rating ID: ' + data.RatingID;
                    $('#RateAPI').html(str);
                })
            .fail(
                function (jqXHR, textStatus, err) {
                    $('#RateAPI').html('Error: ' + err);
                });
}     