using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            List<ListItem> rolesItemList = new List<ListItem>();
            rolesItemList.Add(new ListItem
            {
                Text = RolesConstants.ADMIN,
                Value = RolesConstants.ADMIN
            });

            rolesItemList.Add(new ListItem
            {
                Text = RolesConstants.NORMAL,
                Value = RolesConstants.NORMAL
            });

            ViewBag.Message = rolesItemList;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(Users newUser)
        {
            if (ModelState.IsValid)
            {
                return View(); //TODO
            }

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