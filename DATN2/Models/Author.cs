using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATN2.Models;

public partial class Author
{
    public int Id { get; set; }

    [MaxLength(50, ErrorMessage = "Tên tác giả không quá 50 kí tự")]
    public string? Name { get; set; }

    [MaxLength(100, ErrorMessage = "Địa chỉ không quá 100 kí tự")]
    public string? Address { get; set; }

    [MaxLength(500, ErrorMessage = "Tiểu sử không quá 500 kí tự")]
    public string? Story { get; set; }

    public virtual ICollection<Produce> Produces { get; } = new List<Produce>();
}
