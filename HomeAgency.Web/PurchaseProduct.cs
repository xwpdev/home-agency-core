
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
    
public partial class PurchaseProduct
{

    public int id { get; set; }

    public Nullable<int> product_id { get; set; }

    public Nullable<int> purchase_id { get; set; }

    public Nullable<double> discount { get; set; }

    public Nullable<int> quantity { get; set; }



    public virtual Product Product { get; set; }

    public virtual Purchase Purchase { get; set; }

}

}