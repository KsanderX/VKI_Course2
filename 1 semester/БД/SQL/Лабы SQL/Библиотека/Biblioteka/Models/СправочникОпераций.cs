using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class СправочникОпераций
{
    public int IdОперации { get; set; }

    public virtual ICollection<Формуляры> Формулярыs { get; set; } = new List<Формуляры>();
}
