using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TalentSearch.Models;

namespace TalentSearch.Controllers
{
    public class HomeController : Controller
    {
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

        //captcha validation
        [HttpPost]
        public ActionResult ValidateCaptcha()
        {
            var response = Request["g-recaptcha-response"];
            //secret that was generated in key value pair
            const string secret = "6LdU2SUTAAAAAC4tTSY-nDl1p5lak1hptK0gT0S1";

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0) return PartialView("Register");

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
        }

        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public ActionResult ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            //var result = await Microsoft.AspNet.Identity.UserManager.ConfirmEmailAsync(userId, code);
            //return View(result.Succeeded ? "ConfirmEmail" : "Error");
            if (Session["emailConfirm"].Equals(code))
            {
                return View();
            }
            else
            {
                return View("Error");
            }
        }
    }//end of class
}
