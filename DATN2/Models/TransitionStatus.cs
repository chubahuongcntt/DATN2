using System;
using System.Collections.Generic;

namespace DATN2.Models;

public partial class TransitionStatus
{
    public int Id { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
