module.service("apiService", CreateapiService)

function CreateapiService($http, dataService) {

    this.getImage = () => {
        var num = Math.floor(Math.random() * dataService.images.length);
        return '../../Images/flights/' + dataService.images[num];
    }

    this.getFutureFlights = () => {
        $http.get('http://localhost:60341/api/anonymousFacade/FutureFlights')
            .then((resp) => {
                for (var i = 0; i < resp.data.length; i++) {
                    resp.data[i].image = this.getImage();
                    resp.data[i].LandingTime = resp.data[i].LandingTime.toString().replace('T', ' ');
                    resp.data[i].DepartureTime = resp.data[i].DepartureTime.toString().replace('T', ' ');
                }
                dataService.flights = resp.data
                console.log(dataService.flights)
            }, (err) => { alert('error'); console.log(err) }
            )
    }

    this.getAllCountries = () => {
        $http.get('http://localhost:60341/api/anonymousFacade/GetAllCountries')
            .then((resp) => {
                dataService.countries = resp.data
            }, (err) => { alert('error'); console.log(err) }
            );
    }


}
