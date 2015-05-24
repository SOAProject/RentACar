function currencyService($http, $q) {
    var apiUrl = 'http://apilayer.net/api/live?access_key=e03dc3e194f5c01bfdd6874055f9a094&currencies=USD,BGN,EUR&format=1';

    this.getCurrency = function () {
        var defer = $q.defer();
        $http.get(apiUrl)
        .success(function (data) {
            defer.resolve(data);
        });

        return defer.promise;
    };

    return this;
}