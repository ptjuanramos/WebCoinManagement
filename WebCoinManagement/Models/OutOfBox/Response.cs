using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCoinManagement.Models.OutOfBox
{
    public class LoginResponse
    {
        public String Username { get; set; }
        public String UserRole { get; set; }
    }

    public class Response<T>
    {
        public String Status { get; set; }
        public T Content { get; set; }

        public Response(String status, T content)
        {
            Status = status;
            Content = content;
        }
    }
}