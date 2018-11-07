using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebCoinManagement.Models;
using WebCoinManagement.Models.OutOfBox;

namespace WebCoinManagement.Areas.Api.Controllers
{
    public class AccountController : ApiController
    {
        [Authorize]
        public HttpResponseMessage CheckToken()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                new Response<String>(HttpStatusCode.OK.ToString(), "Token still valid"));
        }

        [HttpPost]
        public HttpResponseMessage SignUp(Users newUser)
        {
            using(CoinManagementContext coinManagementContext = new CoinManagementContext())
            {
                var foundUser = coinManagementContext.Users.SingleOrDefault(u => u.Username.Equals(newUser.Username));
                if(foundUser != null)
                {
                    //TODO
                }
            }

            return null;
        }
    }
}
