using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Shipper
{
    public int ShipperId { get; set; }

    public string? ShipperName { get; set; }

    public decimal? IncomeWallet { get; set; }

    public decimal? CodWallet { get; set; }

    public string? Password { get; set; }

    public string? VehicleType { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int? WarehouseId { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();

    public virtual Warehouse? Warehouse { get; set; }
}
