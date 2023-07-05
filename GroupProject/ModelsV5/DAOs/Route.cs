using System;
using System.Collections.Generic;

namespace ModelsV5.DAOs;

public partial class Route
{
    public int RouteId { get; set; }

    public string? Type { get; set; }

    public decimal? Distance { get; set; }

    public decimal? Price { get; set; }

    public int? ShipperId { get; set; }

    public virtual ICollection<OrderInRoute> OrderInRoutes { get; set; } = new List<OrderInRoute>();

    public virtual Shipper? Shipper { get; set; }
}
