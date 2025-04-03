using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class СправочникОпераций
{
    public int IdОперации { get; set; }

    public virtual ICollection<Формуляры> Формулярыs { get; set; } = new List<Формуляры>();
}
