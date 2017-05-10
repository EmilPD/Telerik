(function () {
    let button = document.getElementById('redirect-button'),
        popup = document.getElementById('popup');

    let promise = new Promise(function(resolve, reject) {
        setTimeout(() => {
            resolve();
        }, 2000);
    });

    function redirect() {
        window.location.assign('another.html');
    };

    function error(err) {
        console.error(`ERROR(${err.code}): ${err.message}`);
    };

    window.onload = () => {
        setTimeout(() => {
            popup.className += ' show';
        }, 500);
        promise
            .then(redirect)
            .catch(error);
    };
}());