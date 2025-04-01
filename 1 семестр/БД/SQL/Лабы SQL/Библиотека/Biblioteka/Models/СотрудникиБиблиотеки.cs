using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class СотрудникиБиблиотеки
{
    public int IdСотрудника { get; set; }

    public virtual ICollection<Формуляры> Формулярыs { get; set; } = new List<Формуляры>();
}
