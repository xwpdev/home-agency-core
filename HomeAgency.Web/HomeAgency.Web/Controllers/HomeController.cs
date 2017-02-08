using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAgency.Web.Controllers
{
    public class HomeController : Controller
    {
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
    }
}