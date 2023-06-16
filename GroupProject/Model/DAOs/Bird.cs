using System;
using System.Collections.Generic;

namespace Model.DAOs;

public partial class Bird
{
    public int BirdId { get; set; }

    public string? BirdName { get; set; }

    public string? BirdType { get; set; }

    public decimal? Weight { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
