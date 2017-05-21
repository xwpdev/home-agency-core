using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAgency.Web.Models
{
    public class InvoiceJsonModel
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string ModeOfPayment { get; set; }
        public string Warehouse { get; set; }
        public string SalesPersonCode { get; set; }
        public CustomerJsonModel CustomerDetails { get; set; }
        public List<ItemJsonModel> ItemList { get; set; }
    }
}