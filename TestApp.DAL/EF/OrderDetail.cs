using System;
using System.Collections.Generic;

namespace TestApp.DAL.EF;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }

    public decimal TotalPrice { get; set; }

    public int CustomerOrderId { get; set; }

    public virtual CustomerOrder CustomerOrder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
