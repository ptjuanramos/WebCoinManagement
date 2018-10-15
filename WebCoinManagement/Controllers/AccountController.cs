using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebCoinManagement.Models;

namespace WebCoinManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login page starting page
        public ActionResult Index() {
            if(Session["username"] != null && Session["password"] != null) {
                return View();
            }

            return View("Login");
        }

        //POST: Login action
        [HttpPost]
        public ActionResult Login(LoginInformation loginInformation) {
            Task<Boolean> verificationTask =  VerifyLoginInformation(loginInformation);
            verificationTask.Wait();

            if(verificationTask.Result) {
                Session["username"] = loginInformation.Username;
                Session["password"] = loginInformation.Password;
                return View("Index");
            }

            return View();
        }

        public ActionResult Logout() {
            Session.RemoveAll();
            return View("Login");
        }

        private Task<Boolean> VerifyLoginInformation(LoginInformation loginInformation) {
            CoinManagementContext coinManagementContext = new CoinManagementContext();
            var foundUser = coinManagementContext.Users.SingleOrDefault(user => user.Username.Equals(loginInformation.Username));

            if(foundUser != null) {
                if(foundUser.Password.Equals(loginInformation.Password)) { //next iteration encryption
                    return Task.FromResult<Boolean>(true);
                } else {
                    return Task.FromResult<Boolean>(false);
                }
            } 

            return Task.FromResult<Boolean>(false);
        }
    }
}