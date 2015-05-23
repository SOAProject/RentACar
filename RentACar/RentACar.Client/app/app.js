var app = angular.module("rentACar", ['ngRoute'])
    .controller('carsListController', carsListController)
    .controller('carsController', carsController)
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'app/views/carsList.html',
                controller: 'carsListController'
            })
            .when('/edit/:id', {
                templateUrl: 'app/views/Edit.html',
                controller: 'carsController',
            })
            .when('/create', {
                templateUrl: 'app/views/Edit.html',
                controller: 'carsController',
            })
            .otherwise({ redirectTo: '/' });
    })
    .constant('baseServiceUrl', 'http://localhost:58623/');