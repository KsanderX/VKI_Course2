using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Полки
{
    public int IdПолки { get; set; }

    public int? Fkряда { get; set; }

    public virtual Ряды? FkрядаNavigation { get; set; }

    public virtual ICollection<Ячейки> Ячейкиs { get; set; } = new List<Ячейки>();
}
