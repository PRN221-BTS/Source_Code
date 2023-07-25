using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelsV6.DAOs;

public partial class Bird
{
    public int BirdId { get; set; }


    public string? BirdName { get; set; }

    public string? BirdType { get; set; }

    [Range(0,800)]
    public decimal? Weight { get; set; }
    [Range(0,100)]
    public int? BirdQuantity { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
