using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAgency.Web.Controllers
{
    public class LoginController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
            logger.Info($"User logout at {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}");
            return RedirectToAction("Index", "Login");
        }

        // POST: Login/Indexk
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (username == "admin" && password == "abc@123")
            {
                logger.Info($"{username} login at {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}");
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}