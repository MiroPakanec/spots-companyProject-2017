function getMarker(map, featureMarker, title) {

    var icons = getIcons();
    console.log(icons);

    var marker = new google.maps.Marker({
        position: featureMarker.position,
        icon: icons[featureMarker.type].icon,
        map: map
    });

    return marker;
}

function getIcons() {

    var iconBase = 'https://maps.google.com/mapfiles/kml/shapes/';

    var icons = {
        info: {
            icon: iconBase + 'info-i_maps.png'
        }
    }

    return icons;
}

function getPosition(latitude, longitude) {
    
    return new google.maps.LatLng(latitude, longitude);
}

function getDefaultZoom() {
    return 15;
}

function getFeatureMarker(position, type) {

    var featureMarker = {
        position: position,
        type: type
    }

    return featureMarker;
}

function getMap(mapOptions) {
    var map = new google.maps.Map(document.getElementById("smap"), mapOptions);
    return map;
}

function getMarkersFromGeolocations(jsonGeolocations) {
            
    var geolocations = jsonGeolocations;
    var features = [];
    console.log(geolocations);

    for(var location in geolocations) {
        if (geolocations.hasOwnProperty(location) === false) continue;

        var latitude = geolocations[location].Latitude;
        var longitude = geolocations[location].Longitude;

        console.log("lat: " + latitude);
        console.log("lng: " + longitude);

        features.push({
            position: new google.maps.LatLng(latitude, longitude),
            type: 'info'
        });                          
    }

    return features;
}