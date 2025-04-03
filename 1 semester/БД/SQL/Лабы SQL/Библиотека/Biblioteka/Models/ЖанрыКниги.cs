using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class ЖанрыКниги
{
    public int IdЖанраКниги { get; set; }

    public int? Fkкниги { get; set; }

    public int? Fkжанра { get; set; }

    public virtual Жанры? FkжанраNavigation { get; set; }

    public virtual Книги? FkкнигиNavigation { get; set; }
}
