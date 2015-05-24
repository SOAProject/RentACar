function rentsController($scope, $routeParams, $http, $location, baseServiceUrl) {
    $scope.location = $location.url();
    var id = $routeParams['id'];
    $scope.title = 'Rent car with Id: ' + id;
    $scope.currentRent = {
        CarId: id
    };

    var currentRentCarUrl = baseServiceUrl + 'api/rents/';
    $scope.rent = function () {
        $http.post(currentRentCarUrl, $scope.currentRent).then(function (res) {
            $location.path("/");
        });
    }
}