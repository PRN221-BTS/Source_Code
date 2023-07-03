using System;
using System.Collections.Generic;

namespace ModelsV4.DAOs;

public partial class OrderInRoute
{
    public int OrderInRouteId { get; set; }

    public int? OrderId { get; set; }

    public int? RouteId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Route? Route { get; set; }
}
