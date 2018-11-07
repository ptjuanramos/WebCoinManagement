using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCoinManagement.Models;
using WebCoinManagement.Services;

namespace WebCoinManagement.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Index", "Account");
        }

        [Authorize]
        public ActionResult Logout()
        {
            CleanAuthenticationSession();
            return RedirectToAction("Index", "Account");
        }

        private void CleanAuthenticationSession()
        {
            var owinContext = Request.GetOwinContext();
            var authenticationManager = owinContext.Authentication;
            authenticationManager.SignOut();
            Session.Abandon();
        }

        public ActionResult AddCollectionItem()
        {
            return View();
        }

        public ActionResult AddCollectionSheet()
        {
            return View();
        }

        public ActionResult CollectionItemsList()
        {
            return View();
        }

        public ActionResult AddCollectionCategory()
        {
            return View();
        }

        public ActionResult AddCollectionCategory(CoinsCategory coinsCategory)
        {
            return View(); //TODO
        }

        public ActionResult AddFriend()
        {
            return View();
        }

        public ActionResult AddFriend(string username)
        {
            using(CoinManagementContext coinManagementContext = new CoinManagementContext())
            {
                string currentUsername = User.Identity.Name;
                FriendsList friendsList = new FriendsList();
                friendsList.FriendOwner = UserService.GetUserIdByUsername(currentUsername);
                friendsList.Friend = UserService.GetUserIdByUsername(username);

                coinManagementContext.FriendsLists.Add(friendsList);
            }

            //TODO - view friend added
            return View();
        }
    }
}