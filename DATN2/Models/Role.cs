using System;
using System.Collections.Generic;

namespace DATN2.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
