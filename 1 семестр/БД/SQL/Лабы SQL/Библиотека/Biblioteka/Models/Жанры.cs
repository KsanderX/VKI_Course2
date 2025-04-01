using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class Жанры
{
    public int IdЖанра { get; set; }

    public virtual ICollection<ЖанрыКниги> ЖанрыКнигиs { get; set; } = new List<ЖанрыКниги>();
}
