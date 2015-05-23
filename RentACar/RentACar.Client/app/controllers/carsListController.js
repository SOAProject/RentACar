function carsListController($scope, $http, baseServiceUrl) {
    $scope.title = 'Cars list';

    var allCarsUrl = baseServiceUrl + 'api/cars';
    $scope.allCars = [];

    $http.get(allCarsUrl).then(
        function (res) {
            $scope.allCars = res.data;
        }
    )
}