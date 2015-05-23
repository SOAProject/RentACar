function carsController($scope, $route,$routeParams, $http, $location, baseServiceUrl) {
    var title = 'Create car';
    var id = $routeParams['id'];
    $scope.currentCar = {};
    if (id) {
        //Edit
        title = 'Edit car with ID: ' + id;
        var currentCarUrl = baseServiceUrl + 'api/cars/' + id;
        
        $http.get(currentCarUrl).then(function (res) {
            $scope.currentCar = res.data;
        });
    } 
    $scope.title = title;

    $scope.edit = function (id) {
        if (id) {
            var updateUrl = baseServiceUrl + 'api/cars/' + id;
            $http.put(updateUrl, $scope.currentCar).then(function (res) {
                $location.path("/");
            });
        } else {
            var createUrl = baseServiceUrl + 'api/cars/';
            $http.post(createUrl, $scope.currentCar).then(function (res) {
                $location.path("/");
            });
        }
    }

    $scope.delete = function (id) {
        var deleteUrl = baseServiceUrl + 'api/cars/'+id;
        $http.delete(deleteUrl).then(function (res) {
            $route.reload();
        });
    }
}