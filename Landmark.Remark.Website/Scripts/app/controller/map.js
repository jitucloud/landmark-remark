app.controller('mapController', function ($scope, mapservice, $timeout) {

    $scope.melbourne = { lat: -37.811263, lng: 144.963151 };

    var iconBase = 'https://maps.google.com/mapfiles/kml/shapes/';

    $scope.icons = {
        parking: {
            icon: iconBase + 'parking_lot_maps.png'
        },
        library: {
            icon: iconBase + 'library_maps.png'
        },
        info: {
            icon: iconBase + 'info-i_maps.png'
        }
    };
    $scope.filter = ""
    $scope.map = "";
    $scope.showmessage = false;
    $scope.username = "";
    $scope.remark = "";

    $scope.location = $scope.melbourne;

    $scope.loadMapWithCurrentPosition = function () {
        if (navigator.geolocation) {
            const options = {
                enableHighAccuracy: true,
                timeout: 2000,
                maximumAge: 0
            };
            navigator.geolocation.getCurrentPosition(this.handleLocationChange, this.handleLocationError, options);
        }
        else {
            $scope.initMap();
        }
    };

    $scope.handleLocationChange = function (location) {
        $scope.location = {
            lat: location.coords.latitude,
            lng: location.coords.longitude
        };
        $scope.initMap();
    };

    $scope.handleLocationError = function (error) {
        console.log("error.code :" + error.code);
        console.log("error.message :" + error.message);
        $scope.showmessage = true;
        $scope.geolocationfailed = "Geo location service failed to get current location. Click on the map to choose the desired location";
        $scope.initMap();
    };

    $scope.initMap = function () {
        const options = {
            center: $scope.location,
            zoom: 15,
            fullscreenControl: false,
            mapTypeControl: false,
            streetViewControl: false,
            zoomControl: false
        };

        $scope.map = new google.maps.Map(document.getElementById('map'), options);
        this.infoWindow = new google.maps.InfoWindow();
        this.marker = new google.maps.Marker({
            position: $scope.location,
            map: this.map,
            optimized: false,
            zIndex: 0
        });

        this.map.addListener('click', $scope.setCurrentLocation);
        $scope.renderRemarkNotes($scope.filter);

        //$timeout(function () {
        //    $scope.renderRemarkNotes($scope.filter);
        //}, 100);
    }

    $scope.renderRemarkNotes = function (filter) {
        mapservice.GetAllNotes(filter)
          .then(function (notes) {
              $scope.createMarkerOnMap(notes);
          });
    };

    $scope.toggleBounce = function () {
        if (marker.getAnimation() !== null) {
            marker.setAnimation(null);
        } else {
            marker.setAnimation(google.maps.Animation.BOUNCE);
        }
    }

    $scope.setCurrentLocation = function (e) {       
        $scope.$apply(function () {
            $scope.location = {
                lat: e.latLng.lat(),
                lng: e.latLng.lng()
            };
        });
    }

    $scope.createMarkerOnMap = function (notes) {
        angular.forEach(notes, function (note, key) {
            var position = {
                lat: note.Lattitude,
                lng: note.Longitude
            };
            this.marker = new google.maps.Marker({
                position: position,
                map: $scope.map,
                icon: $scope.icons.parking.icon,
                title: "username: " + note.UserName + "," + "note: " + note.Note

            });
        });
    };

    $scope.postRemarkForCurrentLocation = function () {

        if ($scope.location.lat !== $scope.melbourne.lat && $scope.location.lng !== $scope.melbourne.lng) {

            mapservice.PostNewNotes($scope.username, $scope.location.lat, $scope.location.lng, $scope.remark)
                .then(function (result) {
                    console.log(result);
                    if (result === "true") {
                        $scope.initMap();
                    }
                });
        }
        else {
            $scope.showmessage = true;
            $scope.geolocationfailed = "Current location is same as default location,can't create note.Click on the map to choose the desired location";
        }
    }

});