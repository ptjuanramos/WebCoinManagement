using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCoinManagement.Models.Views;

namespace WebCoinManagement.Controllers
{
    public class OutOfBoxController : Controller
    {
        // GET: ChangePassword
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult ChangePassword(ChangePasswordInfo changePasswordInfo)
        {
            if(ModelState.IsValid)
            {
                //TODO do stuff
            }

            return View();
        }
    }
}