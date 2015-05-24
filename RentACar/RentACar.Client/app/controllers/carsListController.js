function carsListController($scope, $http, $location, baseServiceUrl) {
    $scope.title = 'Cars list';
    $scope.location = $location.url();
    var allCarsUrl = baseServiceUrl + 'api/cars';
    $scope.allCars = [];

    $http.get(allCarsUrl).then(
        function (res) {
            $scope.allCars = res.data;
        }
    )
}