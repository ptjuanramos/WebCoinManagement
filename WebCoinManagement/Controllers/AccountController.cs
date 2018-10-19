using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebCoinManagement.Models;

namespace WebCoinManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login page starting page
        [AllowAnonymous]
        public ActionResult Index() {
            return View("Login");
        }

        //POST: Login action
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginInformation loginInformation) {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Task<Users> verificationTask = VerifyLoginInformation(loginInformation);
            verificationTask.Wait();

            Users resultUser = verificationTask.Result;

            if (resultUser != null) {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, resultUser.Username), new Claim(ClaimTypes.Role, resultUser.UserRole) };
                var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var owinContext = Request.GetOwinContext();
                var authenticationManager = owinContext.Authentication;
                authenticationManager.SignIn(id);

                if (resultUser.UserRole.Equals("ADMIN"))
                {
                    return RedirectToAction("Index", "Admin");
                } else
                {
                    return RedirectToAction("Index", "User");
                }
            }

            return View();
        }

        private Task<Users> VerifyLoginInformation(LoginInformation loginInformation) {
            CoinManagementContext coinManagementContext = new CoinManagementContext();
            var foundUser = coinManagementContext.Users
                .SingleOrDefault(user => user.Username.Equals(loginInformation.Username) || user.Email.Equals(loginInformation.Username));

            if (foundUser != null) {
                if (foundUser.Password.Equals(loginInformation.Password)) { //next iteration encryption
                    return Task.FromResult<Users>(foundUser);
                } else {
                    return Task.FromResult<Users>(null);
                }
            }

            return Task.FromResult<Users>(null);
        }

    }

    public class RolesConstants
    {
        public const string ADMIN = "ADMIN";
        public const string NORMAL = "NORMAL";   
    }
}