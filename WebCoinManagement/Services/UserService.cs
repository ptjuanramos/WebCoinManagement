using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCoinManagement.Models;

namespace WebCoinManagement.Services
{
    public class UserService
    {
        public static int GetUserIdByUsername(String username)
        {
            using(CoinManagementContext coinManagementContext = new CoinManagementContext())
            {
                var user = coinManagementContext.Users.SingleOrDefault(u => u.Username.Equals(username));
                if(user != null)
                {
                    return user.ID;
                }

                return 0;
            }
        }

        //TODO - next iteration encrypted password
        public static String GenerateTemporaryPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}