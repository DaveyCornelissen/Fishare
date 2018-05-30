function initMap() {
    var uluru = { lat: 51.451768, lng: 5.480999 };
    var map = new google.maps.Map(document.getElementById('Map'), {
        zoom: 16,
        center: uluru
    });
    var marker = new google.maps.Marker({
        position: uluru,
        map: map
    });
}