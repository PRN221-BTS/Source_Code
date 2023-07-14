using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class OrderInRoute
{
    public int OrderInRouteId { get; set; }

    public int? OrderId { get; set; }

    public int? RouteId { get; set; }

    public string? Status { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Route? Route { get; set; }
}
