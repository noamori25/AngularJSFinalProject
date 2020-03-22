using ProjectManagmentSystem.BLL;
using ProjectManagmentSystem.Facade;
using ProjectManagmentSystem.POCO;
using ProjectManagmentSystem.POCO.Views;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:56894", headers: "*", methods: "*")]
    public class AnonymousFacadeController : ApiController
    {
        private AnonymousUserFacade _anonymous;

        public AnonymousFacadeController()
        {
            _anonymous = new AnonymousUserFacade();
        }

        //GetAllFlights: api/AnonymousFacade/GetAllFligts
        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousFacade/GetAllFlights")]
        [HttpGet]
        public IHttpActionResult GetAllFlights()
        {
            IList<Flight> allFlights = _anonymous.GetAllFlights();
            if (allFlights.Count == 0)
                return NotFound();
            return Ok(allFlights);
        }

        //GetAllAirlineCompanies: api/AnonymousFacade/GetAllAirlineComapanies
        [ResponseType(typeof(List<AirlineCompany>))]
        [Route("api/anonymousFacade/GetAllAirlineCompanies")]
        [HttpGet]
        public IHttpActionResult GetAllAirlineComapanies()
        {
            IList<AirlineCompany> airlineCompanies = _anonymous.GetAllAirlineCompanies();
            if (airlineCompanies.Count == 0)
                return NotFound();
            return Ok(airlineCompanies);
        }

        //GetAllFlightsVacancy: api/AnonymousFacade/GetAllFlightsVacancy
        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousFacade/GetAllFlightsVacancy")]
        [HttpGet]
        public IHttpActionResult GetAllFlightsVacancy()
        {
            Dictionary<Flight, int> flightsVacancy = _anonymous.GetAllVacancyFlights();
            if (flightsVacancy.Count == 0)
                return NotFound();
            return Ok(flightsVacancy.ToList());
        }

        //GetFlightsById: api/AnonymousFacade/GetFlightById
        [ResponseType(typeof(Flight))]
        [Route("api/anonymousFacade/GetFlightById/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightById(int id)
        {
            if (id <= 0)
                return StatusCode(HttpStatusCode.NoContent);
            Flight flight = _anonymous.GetFlightById(id);
            if (flight == null)
                return NotFound();
            return Ok(flight);
        }

        //GetFlightsByOriginCountry: api/AnonymousFacade/FlightsByOriginCountry
        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousFacade/GetFlightsByOriginCountry/{countryCode}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByOriginCountry(int countryCode)
        {
            IList<Flight> flightsByOriginCountry = _anonymous.GetFlightsByOriginCountry(countryCode);
            if (flightsByOriginCountry.Count == 0)
                return NotFound();
            return Ok(flightsByOriginCountry);
        }

        //GetFlightsByDestinationCountry: api/AnonymousFacade/FlightsByDestinationCountry
        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousFacade/GetFlightsByDestinationCountry/{countryCode}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByDestinationCountry(int countryCode)
        {
            IList<Flight> flightsByDestinationCountry = _anonymous.GetFlightsByDestinationCountry(countryCode);
            if (flightsByDestinationCountry.Count == 0)
                return NotFound();
            return Ok(flightsByDestinationCountry);
        }

        //Query parameters
        //GetFlightsByDepatrureDate: api/AnonymousFacade/FlightsByDepatrureDate?year=..&month=..&day=..
        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousFacade/GetFlightsByDepartrureDate")]
        [HttpGet]
        public IHttpActionResult GetFlightsByDepartureDate(int year = 0, int month = 0, int day = 0)
        {
            DateTime departureDate = new DateTime(year, month, day);
            IList<Flight> flightsByDepartureDate = _anonymous.GetFlightsByDepartureDate(departureDate);
            if (flightsByDepartureDate.Count == 0)
                return NotFound();
            return Ok(flightsByDepartureDate);
        }

        //Query parameters
        //GetFlightsByLandingDate: api/AnonymousFacade/FlightsByLandingDate
        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousFacade/GetFligtsByLandingDate")]
        [HttpGet]
        public IHttpActionResult GetFlightsByLandingDate(int year = 0, int month = 0, int day = 0)
        {
            DateTime landingDate = new DateTime(year, month, day);
            IList<Flight> flightsByLandingDate = _anonymous.GetFlightsByLandingDate(landingDate);
            if (flightsByLandingDate.Count == 0)
                return NotFound();
            return Ok(flightsByLandingDate);
        }

        //GetDepartureFlightsForTheNext12Hours: api/AnonymousFacade/12HoursDeparture
        [ResponseType(typeof(List<DepartureView>))]
        [Route("api/anonymousFacade/12HoursDeparture")]
        [HttpGet]
        public IHttpActionResult GetDepartureForTheNext12H ()
        {
            IList<DepartureView> departure12H = _anonymous.DepartureForTheNext12H();
            if (departure12H.Count == 0)
                return NotFound();
            return Ok(departure12H);
        }

        //GetLandingFlightsForTheNext12hAndLast4h: api/AnonymousFacade/Next12hLast4hLanding
        [ResponseType(typeof(List<LandingView>))]
        [Route("api/anonymousFacade/Next12hLast4hLanding")]
        [HttpGet]
        public IHttpActionResult GetLandingForTheNext12hAndLast4h()
        {
            IList<LandingView> landingflights = _anonymous.LandingNext12hAndLast4h();
            if (landingflights.Count == 0)
                return NotFound();
            return Ok(landingflights);
        }

        //SearchByAirlineName: api/AnonymousFacade/SearchByParams
        [ResponseType(typeof(List<SearchView>))]
        [Route("api/anonymousFacade/SearchByParams")]
        [HttpPost]
        public IHttpActionResult SearchByParams ([FromBody] SearchQueryParams searchParams)
        {
            if (searchParams == null)
                return StatusCode(HttpStatusCode.NoContent);
            IList<SearchView> searchList = _anonymous.SearchByParams(searchParams);
            if (searchList.Count == 0)
                return NotFound();
            return Ok(searchList);
        }

        //GetFlightsForCardsPage : api/AnonymousFacade/GetFutureFlights
        [ResponseType(typeof(List<FlightCard>))]
        [Route("api/anonymousFacade/FutureFlights")]
        [HttpGet]
        public IHttpActionResult GetFutureFlights ()
        {
            IList<FlightCard> flights = _anonymous.GetFutureFlightsCards();
            if (flights.Count == 0)
                return NotFound();
            return Ok(flights);
        }

        public IHttpActionResult GetAllCountries ()
        {
            IList<Country> countries = _anonymous.GetAllCountries();
            if (countries.Count == 0)
                return NotFound();
            return Ok(countries);
        }
        //ClientRegisterCustomer : api/AnonymousFacade/RegisterCustomer
        [Route("api/anonymousFacade/RegisterCustomer")]
        public IHttpActionResult RegisterCustomer ([FromBody] Customer customer)
        {
            if (customer != null)
            {
                try
                {
                    _anonymous.RegisterCustomer(customer);
                    ExecuteEmailCustomer(customer);
                    return Ok(customer);
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.NotAcceptable, $"{customer} your request are not acceptable, make sure all your details completed {e.Message}");
                }
            }
            return Content(HttpStatusCode.NotAcceptable, $"{customer} your request are not acceptable, make sure all your details completed");


        }

        //ClientRegisterRequestAirline : api/AnonymousFacade/RegisterRequestAirline
        [Route("api/anonymousFacade/RegisterRequestAirline")]
        public IHttpActionResult RegisterRequestAirline ([FromBody]AirlineCompany airline)
        {
            if (airline != null)
            {
                try
                {
                    _anonymous.RegisterRequestAirlineToRabbit(airline);
                    ExecuteEmailAirline(airline);
                    return Ok(airline);
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.NotAcceptable, $"{airline} not acceptable");
                }
               
            }
            return Content(HttpStatusCode.NotAcceptable, $"{airline} not acceptable");
              
        }
        //redis
        //public IHttpActionResult RegisterCustomer ([FromBody]Customer customer)
        //{
        //    var registerService = new RegistrationService();
        //   bool success = registerService.RegistrationRequest(customer);
        //    if (success)
        //        return Ok($"Your request accepted, check you mailbox");
        //    return Content(HttpStatusCode.InternalServerError, $"sorry {customer.FirstName}, try again later");

        //}

        private void ExecuteEmailCustomer(Customer customer)
        {
            var key = "SG.uRzeJTBHR9m7TH2f69YjA.pVS5F3zrks2gZrCeB-Tslb7b3O60-PTRawrxBi6eNFs";
            // var apiKey = Environment.GetEnvironmentVariable(key);
            var client = new SendGridClient(key);
            var from = new EmailAddress(ConfigurationManager.AppSettings["EmailFrom"], ConfigurationManager.AppSettings["ComapnyName"]);
            var subject = "Register completed!!";
            var to = new EmailAddress(customer.UserName, $"{customer.FirstName} {customer.LastName}");
            var plainTextContent = "Thank you for join us, we gald to have you, check our website :)";
            var htmlContent = "<strong>Thank you for join us, we gald to have you, check our website :)</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            // var response = await client.SendEmailAsync(msg);
            var response = client.SendEmailAsync(msg).Result;
        }

        private void ExecuteEmailAirline(AirlineCompany airline)
        {
            var key = "SG.uRzeJTBHR9m7TH2f69YjA.pVS5F3zrks2gZrCeB-Tslb7b3O60-PTRawrxBi6eNFs";
            // var apiKey = Environment.GetEnvironmentVariable(key);
            var client = new SendGridClient(key);
            var from = new EmailAddress(ConfigurationManager.AppSettings["EmailFrom"], ConfigurationManager.AppSettings["ComapnyName"]);
            var subject = "Register completed!!";
            var to = new EmailAddress(airline.UserName, $"{airline.AirlineName}");
            var plainTextContent = "Thank for your request, we will update you soon, check our website :)";
            var htmlContent = "<strong>Thank for your request, we will update you soon, check our website :)</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            // var response = await client.SendEmailAsync(msg);
            var response = client.SendEmailAsync(msg).Result;
        }
    }
}
