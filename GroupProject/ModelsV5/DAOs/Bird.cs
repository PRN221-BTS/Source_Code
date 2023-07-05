using System;
using System.Collections.Generic;

namespace ModelsV5.DAOs;

public partial class Bird
{
    public int BirdId { get; set; }

    public string? BirdName { get; set; }

    public string? BirdType { get; set; }

    public decimal? Weight { get; set; }

    public int? BirdQuantity { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
