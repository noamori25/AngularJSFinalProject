using ProjectManagmentSystem.POCO;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class PageController : Controller
    {

      
        //public ActionResult Email ()
        //{
        //    Execute().Wait();
        //    return Content("Email");
        //}
        // GET: DepartureFlights
        public ActionResult Departure()
        {
            return new FilePathResult("~/Pages/DeparturesFlights.html", "text/html");
        }
        // GET: LandingFlights
        public ActionResult Landing()
        {
            return new FilePathResult("~/Pages/LandingFlights.html", "text/html");
        }
        // GET: Search
        public ActionResult Search()
        {
            return new FilePathResult("~/Pages/Search.html", "text/html");
        }

        //Get: FutureFlights
        [Route("FutureFlights")]
        public ActionResult FutureFlights ()
        {
            return new FilePathResult("~/Pages/FutureFlights.html", "text/html");
        }
        //Get: CreateCustomerAccount
        [Route("CreateCustomerAccount")]
        public ActionResult CreateCustomerAccount()
        {
            return new FilePathResult("~/Pages/CreateCustomerAccount.html", "text/html");
        }
        //Get: HomePage
        public ActionResult HomePage()
        {
            return new FilePathResult("~/Pages/HomePage.html", "text/html");
            
        }

        //Get: ResiterAirlineCompany
        [Route("RegisterAirlineCompany")]
        public ActionResult RegisterAirlineCompany()
        {
            return new FilePathResult("~/Pages/RegisterAirlineCompany.html", "text/html");

        }

        //Get: MoreInfo
        [Route("MoreInfo")]
        public ActionResult MoreInfo ()
        {
            return new FilePathResult("~/Pages/MoreInfoFlight.html", "text/html");
        }

    }
}