using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAgency.Web.Controllers
{
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET: Home/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        // GET: Home/Brand
        public ActionResult Brand()
        {
            return View();
        }

        // GET: Home/Category
        public ActionResult Category()
        {
            return View();
        }

        // GET: Home/Product
        public ActionResult Product()
        {
            return View();
        }

        // GET: Home/Details
        public ActionResult Details()
        {
            return View();
        }

        // GET: Home/Shops
        public ActionResult Shops()
        {
            return View();
        }

        // GET: Home/Agents
        public ActionResult Agents()
        {
            return View();
        }
    }
}