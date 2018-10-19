using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebCoinManagement.Models;

namespace WebCoinManagement.Controllers
{
    [Authorize(Roles = RolesConstants.ADMIN)]
    public class AddUserController : Controller
    {
        // GET: AddUser
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Add(Users newUser) {
            if(ModelState.IsValid) {
                return View("Index", AddNewUser(newUser));
            }

            return View("Index");
        }

        private Users AddNewUser(Users newUser) {
            return null;
        }
    }
}