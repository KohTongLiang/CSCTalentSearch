using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TalentSearch.Models;

namespace TalentSearch.Controllers
{
    public class HomeController : Controller
    {
        CSCAssignment2Entities db = new CSCAssignment2Entities();

        public ActionResult Test()
        {
            ViewBag.Title = "Test";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            return View();
        }

        public ActionResult GetWeather(string city, string country)
        {
            string xml = "";

            using (var client = new ServiceReferenceGlobalWeather.GlobalWeatherSoapClient("GlobalWeatherSoap"))
            {
                var result = client.GetWeather(city, country);
                xml = result;
            }

            return Content(xml, "text/xml");
        }

        public ActionResult GetLocation(string ip)
        {
            string xml = "";

            using (var client = new ServiceReferenceLocation.GeoIPServiceSoapClient("GeoIPServiceSoap"))
            {
                var result = client.GetGeoIP(ip);
                xml = result.ToString();
            }

            return Content(xml, "text/xml");
        }

        //captcha validation
        [HttpPost]
        public ActionResult Register()
        {
            var response = Request["g-recaptcha-response"];
            //secret that was generated in key value pair
            const string secret = "6Leg-SUTAAAAALC9__SsZXAFDkBaXRL7nBH5ytKk";

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                try
                {
                    if (captchaResponse.ErrorCodes.Count <= 0) return PartialView("Register");
                }
                catch
                {
                    return Redirect("/"); //redirect back to home when there are errors - like refreshing the registration form
                }

                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        ViewBag.Message = "The secret parameter is missing.";
                        break;
                    case ("invalid-input-secret"):
                        ViewBag.Message = "The secret parameter is invalid or malformed.";
                        break;

                    case ("missing-input-response"):
                        ViewBag.Message = "The response parameter is missing.";
                        break;
                    case ("invalid-input-response"):
                        ViewBag.Message = "The response parameter is invalid or malformed.";
                        break;

                    default:
                        ViewBag.Message = "Error occured. Please try again";
                        break;
                }
            }
            else
            {
                ViewBag.Message = "Valid";
                //Session["validated"] = true;
            }

            return View("Register");
        }//end of validate captcha controller
    }//end of class
}
