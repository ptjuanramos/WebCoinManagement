using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCoinManagement.Models;

namespace WebCoinManagement.Controllers
{
    public class AdminController : BasePortalController
    {
        // GET: Portal
        [Authorize(Roles = "ADMIN")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public ActionResult SignupUser(Users userToSignup)
        {
            //TODO
            return View();
        }
    }
}