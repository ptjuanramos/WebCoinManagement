using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCoinManagement.Models {
    public class LoginInformation {
        [Required]
        public String Username { get; set; }

        [Required]
        public String Password { get; set; }
    }
}