app.service('mapservice', function ($http, $q) {

    var notes = undefined;

    this.GetAllNotes = function (filter) {

        var deferred = $q.defer();
        var options = {
            method: 'GET',
            url: '/api/notes',
            params: { filter: filter }
        };

        $http(options).then(function (response) {
            notes = response.data;
            deferred.resolve(notes);
        }, function (error) {
            notes = error;
            deferred.reject(error);
        });
        notes = deferred.promise;
        return $q.when(notes);
    }

    this.PostNewNotes = function (username, lattitude, longitude,remark) {

        var status = undefined;

        var postnote = { UserName: username, Lattitude: lattitude, Longitude: longitude, Note: remark };
        var deferred = $q.defer();
        var options = {
            method: 'POST',
            url: '/api/notes',
            data: JSON.stringify(postnote)
        };

        $http(options,postnote).then(function (response) {
            status = response.data;
            console.log(response.data);
            deferred.resolve(status);
        }, function (error) {
            status = error;
            deferred.reject(error);
        });
        status = deferred.promise;
        return $q.when(status);
    }
});