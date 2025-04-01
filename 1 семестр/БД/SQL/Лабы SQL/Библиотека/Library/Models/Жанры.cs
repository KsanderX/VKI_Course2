using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Жанры
{
    public int IdЖанра { get; set; }

    public virtual ICollection<ЖанрыКниги> ЖанрыКнигиs { get; set; } = new List<ЖанрыКниги>();
}
