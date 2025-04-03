using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class Секции
{
    public int IdСекции { get; set; }

    public int? Fkкомнаты { get; set; }

    public virtual Комнаты? FkкомнатыNavigation { get; set; }

    public virtual ICollection<Ряды> Рядыs { get; set; } = new List<Ряды>();
}
