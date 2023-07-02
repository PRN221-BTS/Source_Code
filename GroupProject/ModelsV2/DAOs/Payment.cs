﻿using System;
using System.Collections.Generic;

namespace ModelsV2.DAOs;

public partial class Payment
{
    public int PaymentId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
