function currencyController($scope, $location, currencyService) {
    function init() {
        $scope.location = $location.url();
        var promise = currencyService.getCurrency();
        promise.then(function (currencyObject) {
            $scope.quotes = currencyObject.quotes;
            $scope.curentDate = currencyObject.timestamp * 1000;
        });
    }

    $scope.$on('$routeChangeSuccess', init);
}