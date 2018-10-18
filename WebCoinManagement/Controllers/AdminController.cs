using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCoinManagement.Models;

namespace WebCoinManagement.Controllers
{
    [Authorize(Roles = RolesConstants.ADMIN)]
    public class AdminController : BasePortalController
    {

        public ActionResult SignupUser(Users userToSignup)
        {
            //TODO
            return View();
        }
    }
}