using System;
using System.Collections.Generic;

namespace TestApp.DAL.EF;

public partial class CustomerOrder
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
