/*
 *  Document   : base_comp_maps_full.js
 *  Author     : pixelcave
 *  Description: Custom JS code used in Google Maps Full Page
 */
var BaseCompMapsFull = function () {
    // Gmaps.js, for more examples you can check out https://hpneo.github.io/gmaps/









    function bindInfoWindow(marker, map, infowindow, idH) {

        var content = '<div><div><p><h5>' + marker.title + '</h5></p></div><div><a href="Hospital/Details/' + idH + '"><button class="btn btn-minw btn-rounded btn-primary center-block">Detalhes</button></a></div></div>';


        google.maps.event.addListener(marker, 'click',
            function () {
                infowindow.setContent(content);
                infowindow.open(map, marker);
            }
        );
    }


    // Init Full Map
    var initMapFull = function () {

        var urlPath = "https://cmsrio.azurewebsites.net/api/Hospital";
        var infoWindow = new google.maps.InfoWindow();

        var $mainCon = jQuery('#main-container');
        var $mlat = -22.9271976;
        var $mlong = -43.2096036;
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
            zoom: 13
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


        $.getJSON(urlPath,
            function (json) {
                $.each(json,function (key, data) {

                        //pegas os dados do json pra cada hospital e cria um marker
                        var marker = new google.maps.Marker({
                            position: new google.maps.LatLng(data.Latitude, data.Longitude),
                            map: map123,
                            title: data.Nome,
                        });

                        var idH = data.IDHospital;


                        bindInfoWindow(marker, map123, infoWindow,idH);;

                    }
                );
            }
        );

        var map123 = new google.maps.Map(document.getElementById("js-map-full"), {
            zoom: 13,
            center: new google.maps.LatLng(-22.9271976, -43.2096036),
            MapTypeId: google.maps.MapTypeId.ROADMAP,
            fullscreenControl: false,
            zoomControl: false,
            mapTypeControl: false,
            streetViewControl: false,
        });


    };

    return {
        init: function () {
            // Init Full Map
            initMapFull();

        }
    };
}();

// Initialize when page loads
jQuery(function () { BaseCompMapsFull.init(); });