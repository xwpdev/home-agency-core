using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAgency.Web.Models
{
    public class CustomerJsonModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public AddressJsonModel CustomerBillingAddress { get; set; }
        public AddressJsonModel CustomerDeliveryAddress { get; set; }
    }
}