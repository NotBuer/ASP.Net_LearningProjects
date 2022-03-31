using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ASP.NET_Learning.Services.Data;
using ASP.NET_Learning.Models;

namespace ASP.NET_Learning.Services.Business
{
    public class SecurityServices
    {

        SecurityDAO daoSecurity = new SecurityDAO();

        public bool Authenticate(UserModel user)
        {
            return daoSecurity.FindUser(user);
        }

    }
}