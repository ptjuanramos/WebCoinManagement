using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCoinManagement.Controllers
{
    public class UserController : BasePortalController
    {
        [Authorize(Roles = RolesConstants.NORMAL)]
        public ActionResult Index()
        {
            return View();
        }
    }
}