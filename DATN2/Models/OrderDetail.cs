using System;
using System.Collections.Generic;

namespace DATN2.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? ProduceId { get; set; }

    public int? OrderNumber { get; set; }

    public int? Quantity { get; set; }
    
    public int? Discount { get; set; }

    public int? Total { get; set; }

    public DateTime? ShipDate { get; set; }

    public int? Amount { get; set; }

    public int? TotalMoney { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? Price { get; set; }

    public virtual Order? Order { get; set; }

}
