using System;
using System.Collections.Generic;

namespace DATN2.Models;

public partial class Produce
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Desciption { get; set; }

    public int? CatId { get; set; }

    public int? AutId { get; set; }

    public int? Price { get; set; }

    public int? Discount { get; set; }

    public string? Thumb { get; set; }

    public bool BestSell { get; set; }

    public bool HomeFlag { get; set; }

    public bool Active { get; set; }

    public string? Tag { get; set; }

    public int? UnitslnStock { get; set; }

    public virtual Author? Aut { get; set; }

    public virtual Category? Cat { get; set; }
}
