using System;
using System.Collections.Generic;

namespace ModelsV4.DAOs;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public int? WarehouseManagerId { get; set; }

    public string? WarehouseName { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Shipper> Shippers { get; set; } = new List<Shipper>();

    public virtual ICollection<TrackingOrder> TrackingOrders { get; set; } = new List<TrackingOrder>();

    public virtual WarehouseManager? WarehouseManager { get; set; }
}
