using System;
using System.Collections.Generic;

namespace LibraryManagement.Models;

public partial class Комнаты
{
    public int IdКомнаты { get; set; }

    public virtual ICollection<Секции> Секцииs { get; set; } = new List<Секции>();
}
