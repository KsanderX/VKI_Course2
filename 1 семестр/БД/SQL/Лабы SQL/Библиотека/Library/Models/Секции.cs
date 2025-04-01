using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Секции
{
    public int IdСекции { get; set; }

    public int? Fkкомнаты { get; set; }

    public virtual Комнаты? FkкомнатыNavigation { get; set; }

    public virtual ICollection<Ряды> Рядыs { get; set; } = new List<Ряды>();
}
