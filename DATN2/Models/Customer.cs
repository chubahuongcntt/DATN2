using System;
using System.Collections.Generic;

namespace DATN2.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Avatar { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Password { get; set; }

    public string? Satl { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
