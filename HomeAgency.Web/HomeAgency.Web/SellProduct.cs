
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace HomeAgency.Web
{

using System;
    using System.Collections.Generic;
    
public partial class SellProduct
{

    public int id { get; set; }

    public Nullable<int> product_id { get; set; }

    public Nullable<int> sell_id { get; set; }

    public Nullable<int> discount_id { get; set; }



    public virtual Discount Discount { get; set; }

    public virtual Product Product { get; set; }

    public virtual Sell Sell { get; set; }

}

}
