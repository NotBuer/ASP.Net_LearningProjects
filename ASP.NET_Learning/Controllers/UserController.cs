using ASP.NET_Learning.Models;
using ASP.NET_Learning.Services.Data;
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

        [HttpPost]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult LoginProcess(UserModel user)
        {
            SecurityDAO securityDAO = new SecurityDAO();
            UserModel userModel = securityDAO.LoginUser(user);
            
            // First check if the returned user is valid or not.
            if (UserModel.IsUserValid(userModel))
            {
                // If it is, then redirect the user to the UserHome page.
                //Session["Username"] = user.Name;
                Session.Add("Username", user.Name);
                return View("UserHome", user);
            }
            else
            {
                // Otherwise, redirect again the user to the Login page.
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult RegisterProcess(UserModel user)
        {
            SecurityDAO securityDAO = new SecurityDAO();
            UserModel userModel = securityDAO.CreateUser(user);

            // First check if the returned user is valid or not.
            if (UserModel.IsUserValid(userModel))
            {
                // If it is, then redirect the user to the UserHome page.
                //Session["Username"] = user.Name;
                Session.Add("Username", user.Name);
                return View("UserHome", user);
            }
            else
            {
                // Otherwise, redirect again the user to the Register page.
                return View("Register");
            }
        }

        [HttpPost]
        public ActionResult UserHome(UserModel user)
        {
            return View("UserHome", user);
        }

    }
}