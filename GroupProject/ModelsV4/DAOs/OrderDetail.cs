using System;
using System.Collections.Generic;

namespace ModelsV4.DAOs;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? BirdId { get; set; }

    public string? Certificate { get; set; }

    public string? BirdCage { get; set; }

    public string? OtherItems { get; set; }

    public string? DeliveryStatus { get; set; }

    public decimal? Price { get; set; }

    public virtual Bird? Bird { get; set; }

    public virtual Order? Order { get; set; }
}
