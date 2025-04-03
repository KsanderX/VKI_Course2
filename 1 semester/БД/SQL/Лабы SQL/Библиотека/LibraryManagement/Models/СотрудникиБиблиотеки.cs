using System;
using System.Collections.Generic;

namespace LibraryManagement.Models;

public partial class СотрудникиБиблиотеки
{
    public int IdСотрудника { get; set; }
    public string? Имя { get; set; }

    public virtual ICollection<Формуляры> Формулярыs { get; set; } = new List<Формуляры>();
}
