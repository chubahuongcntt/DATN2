using System;
using System.Collections.Generic;

namespace DATN2.Models;

public partial class Author
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Story { get; set; }

    public virtual ICollection<Produce> Produces { get; } = new List<Produce>();
}
