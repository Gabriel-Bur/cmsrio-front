/*
 *  Document   : base_comp_maps_full.js
 *  Author     : pixelcave
 *  Description: Custom JS code used in Google Maps Full Page
 */


getGeo = function () {
    var map = new google.maps.Map(document.getElementById('js-map-full'), {
        center: { lat: -22.8769124, lng: -43.3189519 },
        zoom: 11
    });




    var infoWindow = new google.maps.InfoWindow({ map: map });

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            infoWindow.setPosition(pos);
            infoWindow.setContent('Location found.');
            map.setCenter(pos);

        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }


}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
}






var BaseCompMapsFull = function () {
    // Gmaps.js, for more examples you can check out https://hpneo.github.io/gmaps/

    // Init Full Map
    var initMapFull = function () {

        var $mainCon = jQuery('#main-container');
        var $mlat = -22.8769124;
        var $mlong = -43.3189519;
        var $rTimeout;

        // Set #main-container position to be relative
        $mainCon.css('position', 'relative');

        // Adjust map container position
        jQuery('#js-map-full').css({
            'position': 'absolute',
            'top': $mainCon.css('padding-top'),
            'right': '0',
            'bottom': '0',
            'left': '0'
        });

        // Init map itself
        var $mapFull = new GMaps({
            div: '#js-map-full',
            lat: $mlat,
            lng: $mlong,
            zoom: 11
        });


        // Set map type
        $mapFull.setMapTypeId(google.maps.MapTypeId.ROADMAP);

        // Resize and center the map on browser window resize
        jQuery(window).on('resize orientationchange', function () {
            clearTimeout($rTimeout);

            $rTimeout = setTimeout(function () {
                $mapFull.refresh();
                $mapFull.setCenter($mlat, $mlong);
            }, 150);
        });

    };

    return {
        init: function () {
            // Init Full Map
            initMapFull();
            getGeo();
        }
    };
}();

// Initialize when page loads
jQuery(function () { BaseCompMapsFull.init(); });