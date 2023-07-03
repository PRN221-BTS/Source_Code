using System;
using System.Collections.Generic;

namespace ModelsV4.DAOs;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Bird> Birds { get; set; } = new List<Bird>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
