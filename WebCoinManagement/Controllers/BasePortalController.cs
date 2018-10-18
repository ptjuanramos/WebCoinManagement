using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCoinManagement.Controllers
{
    public class BasePortalController : Controller
    {

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Index", "Account");
        }

        [Authorize]
        public ActionResult Logout()
        {
            CleanAuthenticationSession();
            return RedirectToAction("Index", "Account");
        }

        private void CleanAuthenticationSession()
        {
            var owinContext = Request.GetOwinContext();
            var authenticationManager = owinContext.Authentication;
            authenticationManager.SignOut();
            Session.Abandon();
        }
    }
}