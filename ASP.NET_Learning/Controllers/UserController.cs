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
            return View("Index");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

    }
}