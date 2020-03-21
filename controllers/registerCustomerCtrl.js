module.controller("registerCustomerCtrl", RegisterCustomerCtrlCtor)

function RegisterCustomerCtrlCtor($scope, $http) {
    $scope.formModel = {
        firstName: '',
        lastName: '',
        userName: '',
        password: '',
        address: '',
        PhoneNo: '' ,
        CreditCardNumber: ''
    };
    $scope.termsService = true;
    $scope.registerRequest = function () {
        $http.post("http://localhost:60341/api/anonymousFacade/RegisterCustomer", JSON.stringify($scope.formModel))
            .then(function (response) {
                $scope.data = response.date;
                swal("Your registration has been completed successfully check your inbox.");
            })
            .catch(function () {
                swal("Registration is not accepted and you can send us an email with your details to Flights@gmail.com")
            });
    };
}
