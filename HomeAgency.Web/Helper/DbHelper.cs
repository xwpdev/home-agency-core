using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAgency.Web.Helper
{
    public static class DbHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        internal static int SaveBrand(string name, bool active)
        {
            try
            {
                using (var context = new homeagencyEntities())
                {
                    // Check for duplicate name
                    if (context.Brands.Where(x => x.name.Trim().Equals(name)).Count() > 0)
                    {
                        return -1;
                    }
                    else
                    {
                        var tempBrand = new Brand { name = name, active = active };
                        context.Brands.Add(tempBrand);
                        context.SaveChanges();
                        return tempBrand.id;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Log(LogLevel.Info, "DbHelper:SaveBrand");
                logger.Error(Ex, "DbHelper:SaveBrand");
                return 0;
            }
        }

        internal static List<Brand> GetBrandData()
        {
            using (var context = new homeagencyEntities())
            {
                return context.Brands.ToList();
            }
        }

        internal static int SaveCategory(string name, bool active)
        {
            try
            {
                using (var context = new homeagencyEntities())
                {
                    // Check for duplicate name
                    if (context.Categories.Where(x => x.name.Trim().Equals(name)).Count() > 0)
                    {
                        return -1;
                    }
                    else
                    {
                        var tempCategory = new Category { name = name, active = active };
                        context.Categories.Add(tempCategory);
                        context.SaveChanges();
                        return tempCategory.id;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Log(LogLevel.Info, "DbHelper:SaveCategory");
                logger.Error(Ex, "DbHelper:SaveCategory");
                return 0;
            }
        }

        internal static List<Category> GetCategoryData()
        {
            using (var context = new homeagencyEntities())
            {
                return context.Categories.ToList();
            }
        }

        internal static List<Product> GetProductData()
        {
            using (var context = new homeagencyEntities())
            {
                return context.Products.Include("Brand").Include("Category").ToList();
            }
        }

        internal static int SaveProduct(string name, int brandId, int categoryId, string reference, bool hasPacks, int perPackCount, int packCount, int quantity, decimal unitPrice, bool active, decimal mrp)
        {
            using (var context = new homeagencyEntities())
            {
                lock (context)
                {
                    try
                    {
                        if (brandId > 0 && categoryId > 0)
                        {
                            var tempProduct = new Product
                            {
                                active = active,
                                brand_id = brandId,
                                category_id = categoryId,
                                items_per_pack = perPackCount,
                                packs = hasPacks,
                                name = name,
                                pack_count = packCount,
                                quantity = quantity,
                                ref_id = reference,
                                unit_price = Convert.ToDouble(unitPrice),
                                mrp = Convert.ToDouble(mrp)
                            };
                            context.Products.Add(tempProduct);
                            context.SaveChanges();
                            return tempProduct.id;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    catch (Exception Ex)
                    {
                        logger.Log(LogLevel.Info, "DbHelper:SaveCategory");
                        logger.Error(Ex, "DbHelper:SaveCategory");
                        return 0;
                    }
                }
            }
        }

        internal static int SaveAgent(string name, string contactNo, bool isActive)
        {
            using (var context = new homeagencyEntities())
            {
                try
                {
                    if (context.Agents.Where(x => x.name.Trim().Equals(name)).Count() > 0)
                    {
                        return -1;
                    }
                    else
                    {
                        var temAgent = new Agent { name = name, is_active = isActive, contact_no = contactNo };
                        context.Agents.Add(temAgent);
                        context.SaveChanges();
                        return temAgent.id;
                    }
                }
                catch (Exception Ex)
                {
                    logger.Log(LogLevel.Info, "DbHelper:SaveAgent");
                    logger.Error(Ex, "DbHelper:SaveAgent");
                    return 0;
                }
            }
        }
    }
}