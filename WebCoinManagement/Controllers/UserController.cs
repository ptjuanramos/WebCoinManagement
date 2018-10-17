using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCoinManagement.Controllers
{
    public class UserController : BasePortalController
    {
        [Authorize(Roles = "NORMAL")]
        public ActionResult Index()
        {
            return View();
        }
    }
}