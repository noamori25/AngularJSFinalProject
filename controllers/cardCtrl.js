module.controller("cardCtrl", CardCtrl)

function CardCtrl($scope, dataService, apiService, $location) {

    apiService.getFutureFlights()
    $scope.dataFlights = dataService

    $scope.go = function (path) {
        $location.path(path)
      
    }

    $scope.open = function (path) {
        window.location.href = path
    }
   
    //var images = new Array('cardexample.jpg', 'japan.jpg', 'london.jpg', 'miami.jpg', 'paris.jpg', 'vegas.jpg');

    //$scope.getImage = function () {
    //    var num = Math.floor(Math.random() * images.length);
    //    return  '../../Images/flights/' + images[num];
    //};
    //$scope.flights = [];
    //$http.get('http://localhost:60341/api/anonymousFacade/FutureFlights')
    //    .then(
    //    (resp) => {
    //        for (var i = 0; i < resp.data.length; i++) {
    //            resp.data[i].image = $scope.getImage();
    //        }
    //            $scope.flights = resp.data;
                
    //        }, (err) => { alert('error'); console.log(err) }
    //);
   
}


