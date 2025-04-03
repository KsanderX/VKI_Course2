using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class ПопулярныеКниги
{
    public int IdПопулярнойКниги { get; set; }

    public int? Fkкниги { get; set; }

    public virtual Книги? FkкнигиNavigation { get; set; }
}
