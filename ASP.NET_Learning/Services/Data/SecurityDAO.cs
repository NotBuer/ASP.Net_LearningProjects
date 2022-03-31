using ASP.NET_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Learning.Services.Data
{
    // Data Access Object
    public class SecurityDAO
    {
        public bool FindUser(UserModel user)
        {
            return user.CPF == 12345678910 && user.Password == "password";
        }
    }
}