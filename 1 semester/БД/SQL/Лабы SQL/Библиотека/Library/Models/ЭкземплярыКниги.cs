using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class ЭкземплярыКниги
{
    public int IdЭкземпляра { get; set; }

    public int? Fkкниги { get; set; }

    public int? Fkячейки { get; set; }

    public virtual Книги? FkкнигиNavigation { get; set; }

    public virtual Ячейки? FkячейкиNavigation { get; set; }

    public virtual ICollection<Формуляры> Формулярыs { get; set; } = new List<Формуляры>();
}
