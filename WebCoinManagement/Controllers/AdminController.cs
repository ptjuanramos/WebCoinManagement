using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebCoinManagement.Models;
using WebCoinManagement.Models.Views.Admin;
using WebCoinManagement.Services;

namespace WebCoinManagement.Controllers
{
    [Authorize(Roles = RolesConstants.ADMIN)]
    public class AdminController : UserController
    {
        public ActionResult UserList() {
            using (CoinManagementContext coinManagementContext = new CoinManagementContext())
            {
                List<Users> users = coinManagementContext.Users.ToList();
                List<UserListItem> items = new List<UserListItem>();

                foreach (Users user in users)
                {
                    UserListItem item = new UserListItem();
                    item.Name = user.Name;
                    item.Role = user.UserRole;
                    item.NumberOfItems = 0; //TODO
                    item.NumberOfTrades = 0; //TODO
                    items.Add(item);
                }

                ViewBag.Message = items;
                return View();
            }
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
        public ActionResult AddUser(Users newUser)
        {
            ModelState.Remove("Password");
            newUser.Password = UserService.GenerateTemporaryPassword();

            if (ModelState.IsValid)
            {
                Task<Users> addedUserTask = AddUserTask(newUser);
                addedUserTask.Wait();
                Users addedUser = addedUserTask.Result;

                if(addedUser == null || addedUser.ID == null)
                {
                    return View(); //TODO - error Message
                }

                return RedirectToAction("UserList"); //TODO - sucess message
            }

            return View(); //TODO - error Message
        }

        private Task<Users> AddUserTask(Users newUser)
        {
            using(CoinManagementContext coinManagementContext = new CoinManagementContext())
            {
                Users returnUser = coinManagementContext.Users.Add(newUser);
                coinManagementContext.SaveChanges();
                return Task.FromResult<Users>(returnUser);
            }

        }

        public ActionResult RemoveUser() {
            return View();
        }

        public ActionResult UsersPemissions() {
            return View();
        }

    }
}