using ASP.NET_Learning.Models;
using ASP.NET_Learning.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Learning.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            return View("User");
        }

        public ActionResult UserLogin(UserModel user)
        {
            SecurityServices securityServices = new SecurityServices();
            bool success = securityServices.Authenticate(user);

            // Redirect the user if login was successful or not.
            return View("NoPage_FixHere!");
        }

    }
}