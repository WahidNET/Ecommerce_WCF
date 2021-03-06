//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
[DataContract(IsReference = true)]
public partial class Order
{
    public Order()
    {
        this.OrderDetail = new HashSet<OrderDetail>();
    }

    [DataMember]
    public int OrderId { get; set; }
    [DataMember]
    public Nullable<System.DateTime> OrderDate { get; set; }
    [DataMember]
    public string UserName { get; set; }
    [DataMember]
    public string FristName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    [DataMember]
    public string Adresse { get; set; }
    [DataMember]
    public string City { get; set; }
    [DataMember]
    public string Stat { get; set; }
    [DataMember]
    public Nullable<int> PostalCode { get; set; }
    [DataMember]
    public string Country { get; set; }
    [DataMember]
    public string Phone { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public Nullable<decimal> Total { get; set; }
    [DataMember]

    public virtual ICollection<OrderDetail> OrderDetail { get; set; }
}
