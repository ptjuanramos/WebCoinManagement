using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCoinManagement.Controllers
{
    public class BasePortalController : Controller
    {
        [AllowAnonymous]
        public ActionResult Logout()
        {
            CleanAuthenticationSession();
            return RedirectToAction("Index", "Login");
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