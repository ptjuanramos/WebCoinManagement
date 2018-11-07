using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCoinManagement.Models.Views.Admin
{
    public class UserListItem
    {
        public String Name { get; set; }
        public String Role { get; set; }
        public int NumberOfItems { get; set; }
        public int NumberOfTrades { get; set; }
    }
}