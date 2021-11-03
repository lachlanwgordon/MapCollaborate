var map;

function initializeMap() {
    mapboxgl.accessToken = 'pk.eyJ1IjoicGhvdG9tYXAiLCJhIjoiS2p5ZDlVcyJ9.YW_JLhYIadrns70Xkwy5hA';
    map = new mapboxgl.Map({
            container: 'map', // container ID
    style: 'mapbox://styles/mapbox/streets-v11', // style URL
    center: [145, -37], // starting position [lng, lat]
    zoom: 9 // starting zoom
    });
    const marker1 = new mapboxgl.Marker()
        .setLngLat([145,-37])
        .addTo(map);
}

function AddMarker(lat, lon) {
    console.log("adding: " + lat + lon);
    const marker2 = new mapboxgl.Marker()
        .setLngLat([lon, lat])
        .addTo(map);
}

function ClearMarkers() {
    console.log("test");
}