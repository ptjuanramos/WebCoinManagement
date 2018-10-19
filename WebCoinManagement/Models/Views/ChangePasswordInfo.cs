using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCoinManagement.Models.Views
{
    public class ChangePasswordInfo
    {
        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string UserToken { get; set; }
    }
}