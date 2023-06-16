using System;
using System.Collections.Generic;

namespace Model.DAOs;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? RouteId { get; set; }

    public string? ReceivingAddress { get; set; }

    public string? SendingAddress { get; set; }

    public string? Note { get; set; }

    public string? Status { get; set; }

    public int? PaymentId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Payment? Payment { get; set; }

    public virtual Route? Route { get; set; }

    public virtual ICollection<TrackingOrder> TrackingOrders { get; set; } = new List<TrackingOrder>();
}
