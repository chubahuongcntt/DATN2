using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATN2.Models;

public partial class Produce
{
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = "Tên sách không quá 100 kí tự")]
    public string Name { get; set; } = null!;

    [MaxLength(500, ErrorMessage = "Mô tả không quá 500 kí tự")]
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

    public DateTime? Datecreate { get; set; }

    public string? Alias { get; set; }

    public string? NhaXB { get; set; }

    public virtual Author? Aut { get; set; }

    public virtual Category? Cat { get; set; }

}
