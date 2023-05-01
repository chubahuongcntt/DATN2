using System;
using System.Collections.Generic;

namespace DATN2.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? ParentId { get; set; }

    public int? Levels { get; set; }

    public int? Odering { get; set; }

    public bool Published { get; set; }

    public string? Thums { get; set; }

    public string? Title { get; set; }

    public string? Cover { get; set; }

    public string? Alias { get; set; }

    public virtual ICollection<Produce> Produces { get; } = new List<Produce>();
}
