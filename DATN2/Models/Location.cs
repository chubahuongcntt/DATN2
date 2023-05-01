using System;
using System.Collections.Generic;

namespace DATN2.Models;

public partial class Location
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Slug { get; set; }

    public string? NameWithType { get; set; }

    public string? PathWithType { get; set; }

    public int? ParentCode { get; set; }

    public int? Level { get; set; }
}
