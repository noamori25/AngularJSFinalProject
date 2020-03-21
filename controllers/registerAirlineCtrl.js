module.controller("registerAirlineCtrl", RegisterAirlineCtrlCtor)

function RegisterAirlineCtrlCtor($scope, $http, dataService, apiService) {
    $scope.formModel = {
        companyName: '',
        userName: '',
        password: '',
        country: ''
    };

    $scope.formModel = dataService
    $scope.dataCountries = dataService
    apiService.getAllCountries()
   

    //$scope.countries = [];
    //$http.get('http://localhost:60341/api/anonymousFacade/GetAllCountries')
    //    .then((resp) => {
    //            $scope.countries = resp.data
    //        }, (err) => { alert('error'); console.log(err) }
    //    );

    $scope.registerRequest = function () {
        $http.post('http://localhost:60341/api/anonymousFacade/RegisterRequestAirline', JSON.stringify($scope.formModel))
            .then((resp) => {
                $scope.data = resp.data;
                swal("thank for your request, check you mail box")
            })
    };


    
}
