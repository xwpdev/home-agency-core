using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAgency.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        // POST: Login/Indexk
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (username == "admin" && password == "abc@123")
            {
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}