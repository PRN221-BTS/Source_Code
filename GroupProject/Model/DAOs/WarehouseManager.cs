﻿using System;
using System.Collections.Generic;

namespace Model.DAOs;

public partial class WarehouseManager
{
    public int WarehouseManagerId { get; set; }

    public string? WarehouseManagerName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
