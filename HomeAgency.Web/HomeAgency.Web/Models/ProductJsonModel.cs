using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAgency.Web.Models
{
    public class ProductJsonModel
    {
        public bool active { get; set; }
        public int brandId { get; set; }
        public int categoryId { get; set; }
        public string name { get; set; }
        public int packCount { get; set; }
        public int perPackCount { get; set; }
        public bool hasPacks { get; set; }
        public int quantity { get; set; }
        public string reference { get; set; }
        public decimal unitPrice { get; set; }
        public decimal mrp { get; set; }
    }
}