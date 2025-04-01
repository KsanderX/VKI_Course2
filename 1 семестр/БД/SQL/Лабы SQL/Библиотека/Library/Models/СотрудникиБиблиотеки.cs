using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class СотрудникиБиблиотеки
{
    public int IdСотрудника { get; set; }

    public virtual ICollection<Формуляры> Формулярыs { get; set; } = new List<Формуляры>();
}
