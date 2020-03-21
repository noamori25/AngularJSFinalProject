module.config(['$locationProvider', function ($locationProvider) {
	$locationProvider.hashPrefix('');
}]);

module.config(function ($stateProvider, $urlRouterProvider) {

	$stateProvider
        .state("FutureFlights", {
            url: "/FutureFlights",
            templateUrl: "/page/FutureFlights",
        	controller: "cardCtrl"
        })
        .state('CreateCustomerAccount', {
            url: '/CreateCustomerAccount',
            templateUrl: "/page/CreateCustomerAccount",
            controller: "registerCustomerCtrl"
            
        })
        .state('RegisterAirlineCompany', {
            url: '/RegisterAirlineCompany',
            templateUrl: "/page/RegisterAirlineCompany",
            controller: "registerAirlineCtrl"
        })
        .state('MoreInfo', {
            url: '/MoreInfo',
            templateUrl: "/page/MoreInfo",
         
        })

    $urlRouterProvider.when("","/FutureFlights")


});