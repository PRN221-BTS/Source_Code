using System;
using System.Collections.Generic;

namespace ModelsV21.DAOs;

public partial class TrackingOrder
{
    public int TrackingOrderId { get; set; }

    public string? TrackingStatus { get; set; }

    public int? SequenceNumber { get; set; }

    public DateTime? EstimateDeliveryDate { get; set; }

    public DateTime? ActualDeliveryDate { get; set; }

    public int? WarehouseId { get; set; }

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
