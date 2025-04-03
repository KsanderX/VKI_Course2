using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Читатели
{
    public int IdЧитателя { get; set; }

    public string? ЧитательскийБилет { get; set; }

    public virtual ICollection<Формуляры> Формулярыs { get; set; } = new List<Формуляры>();
}
