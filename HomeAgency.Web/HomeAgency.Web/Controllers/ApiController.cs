using HomeAgency.Web.Helper;
using HomeAgency.Web.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAgency.Web.Controllers
{
    public class ApiController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // Load Brand Data
        [HttpGet]
        [ActionName("GetBrandData")]
        public ActionResult GetBrandData()
        {
            var obj = new object();
            try
            {
                var data = DbHelper.GetBrandData();
                obj = new { status = true, data = data.Select(x => new { x.id, x.name, x.active }).ToList() };
            }
            catch (Exception Ex)
            {
                logger.Log(LogLevel.Info, "GetBrandData");
                logger.Error(Ex, "GetBrandData");
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        // Save Brand
        [HttpPost]
        [ActionName("SaveBrand")]
        public ActionResult SaveBrand(string name, bool active)
        {
            var obj = new object();
            try
            {
                var newId = DbHelper.SaveBrand(name.Trim(), active);
                obj = new { status = (newId > 0), id = newId };
            }
            catch (Exception Ex)
            {
                logger.Log(LogLevel.Info, "SaveBrand");
                logger.Error(Ex, "SaveBrand");
            }
            return Json(obj);
        }

        // Load Category Data
        [HttpGet]
        [ActionName("GetCategoryData")]
        public ActionResult GetCategoryData()
        {
            var obj = new object();
            try
            {
                var data = DbHelper.GetCategoryData();
                obj = new { status = true, data = data.Select(x => new { x.id, x.name, x.active }).ToList() };
            }
            catch (Exception Ex)
            {
                logger.Log(LogLevel.Info, "GetCategoryData");
                logger.Error(Ex, "GetCategoryData");
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        // Save Brand
        [HttpPost]
        [ActionName("SaveCategory")]
        public ActionResult SaveCategory(string name, bool active)
        {
            var obj = new object();
            try
            {
                var newId = DbHelper.SaveCategory(name.Trim(), active);
                obj = new { status = (newId > 0), id = newId };
            }
            catch (Exception Ex)
            {
                logger.Log(LogLevel.Info, "SaveCategory");
                logger.Error(Ex, "SaveCategory");
            }
            return Json(obj);
        }

        // GetProductData
        [HttpGet]
        [ActionName("GetProductData")]
        public ActionResult GetProductData()
        {
            var obj = new object();
            try
            {
                var data = DbHelper.GetProductData();
                obj = new
                {
                    status = true,
                    data = data.Select(x => new
                    {
                        id = x.id,
                        name = x.name,
                        active = x.active,
                        reference = x.ref_id,
                        brand = x.Brand.name,
                        category = x.Category.name,
                        unitPrice = x.unit_price,
                        mrp = x.mrp
                    }).ToList()
                };
            }
            catch (Exception Ex)
            {
                logger.Log(LogLevel.Info, "GetProductData");
                logger.Error(Ex, "GetProductData");
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        // Save Product
        [HttpPost]
        [ActionName("SaveProduct")]
        public ActionResult SaveProduct(ProductJsonModel data)
        {
            var obj = new object();
            try
            {
                var newId = DbHelper.SaveProduct(data.name.Trim(), data.brandId, data.categoryId, data.reference, data.hasPacks, data.perPackCount, data.packCount, data.quantity, data.unitPrice, data.active, data.mrp);
                obj = new { status = (newId > 0), id = newId };
            }
            catch (Exception Ex)
            {
                logger.Log(LogLevel.Info, "SaveProduct");
                logger.Error(Ex, "SaveProduct");
            }
            return Json(obj);
        }
    }
}