(function () {
    let geoLocationPromise = new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(resolve, reject);
    });

    function extractCoords(position) {
        let coords = {
            latt: position.coords.latitude,
            long: position.coords.longitude
        }
        return coords;
    }

    function renderMap(coords) {
        let map = `https://maps.googleapis.com/maps/api/staticmap?center=${coords.latt},${coords.long}&zoom=16&size=500x500`;
        let img = document.createElement('img');
        img.src = map;
        
        let selector = document.getElementById('root');
        selector.appendChild(img);
    }

    function error(err) {
        console.error(`ERROR(${err.code}): ${err.message}`);
    };

    geoLocationPromise
        .then(extractCoords)
        .then(renderMap)
        .catch(error);
}());