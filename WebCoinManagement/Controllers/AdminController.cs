using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCoinManagement.Models;

namespace WebCoinManagement.Controllers
{
    [Authorize(Roles = RolesConstants.ADMIN)]
    public class AdminController : UserController
    {
        public ActionResult UserList() {
            return View();
        }

        public ActionResult AddUser() {
            return View();
        }

        public ActionResult RemoveUser() {
            return View();
        }

        public ActionResult UsersPemissions() {
            return View();
        }

    }
}