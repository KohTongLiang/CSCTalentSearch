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
        }

        // GET: /Home/ConfirmEmail
        [AllowAnonymous]
        [Route("ConfirmEmail")]
        public ActionResult ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            //var result = await Microsoft.AspNet.Identity.UserManager.ConfirmEmailAsync(userId, code);
            //return View(result.Succeeded ? "ConfirmEmail" : "Error");

            AspNetUser user = db.AspNetUsers.ToList().Find(u => u.Id == userId);
            TimeSpan time = new TimeSpan(0, 0, 20, 0);
            DateTime expiryDateTime = (DateTime)user.CodeExpiry;
            if (code == user.ConfirmationCode && expiryDateTime < (expiryDateTime.AddMinutes(time.Minutes)))
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
