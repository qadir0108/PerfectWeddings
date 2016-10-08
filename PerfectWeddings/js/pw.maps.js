
var myCenter = new google.maps.LatLng(23.0203458, 72.5797426);

pw.googleMaps = function initialize() {
    var mapProp = {
        center: myCenter,
        zoom: 9,
        scrollwheel: false,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

    var marker = new google.maps.Marker({
        position: myCenter,

        //icon: 'images/pinkball.png'
    });

    marker.setMap(map);
    var infowindow = new google.maps.InfoWindow({
        content: "Hello Address"
    });
}

google.maps.event.addDomListener(window, 'load', initialize);
