using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAgency.Web.Controllers
{
    public class DataController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET: Data/Bill
        public ActionResult Bill()
        {
            return View();
        }

        // GET: Data/Invoice
        public ActionResult Invoice()
        {
            return View();
        }
    }
}