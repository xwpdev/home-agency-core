using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAgency.Web.Models
{
    public class ItemJsonModel
    {
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int CMU { get; set; }
        public int Cases { get; set; }
        public int Pcs { get; set; }
        public decimal Rate { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal RateAfterDiscount { get; set; }
        public decimal AmountAfterDiscount { get; set; }
        public decimal VAT { get; set; }
    }
}