using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Ряды
{
    public int IdРяда { get; set; }

    public int? Fkсекции { get; set; }

    public virtual Секции? FkсекцииNavigation { get; set; }

    public virtual ICollection<Полки> Полкиs { get; set; } = new List<Полки>();
}
