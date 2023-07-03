using System;
using System.Collections.Generic;

namespace ModelsV4.DAOs;

public partial class WarehouseManager
{
    public int WarehouseManagerId { get; set; }

    public string? WarehouseManagerName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
