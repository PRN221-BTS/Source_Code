﻿using System;
using System.Collections.Generic;

namespace ModelsV6.DAOs;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public string? ReceivingAddress { get; set; }

    public string? SendingAddress { get; set; }

    public string? Note { get; set; }

    public string? OrderType { get; set; }

    public string? Status { get; set; }

    public string? Properties { get; set; }

    public int? PaymentId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<OrderInRoute> OrderInRoutes { get; set; } = new List<OrderInRoute>();

    public virtual Payment? Payment { get; set; }

    public virtual ICollection<TrackingOrder> TrackingOrders { get; set; } = new List<TrackingOrder>();
}
