using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAgency.Web.Models
{
    public class AddressJsonModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string Country { get; set; }
    }
}