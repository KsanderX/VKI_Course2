using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class АвторыКниги
{
    public int IdАвтораКниги { get; set; }

    public int? Fkкниги { get; set; }

    public int? Fkавтора { get; set; }

    public virtual Авторы? FkавтораNavigation { get; set; }

    public virtual Книги? FkкнигиNavigation { get; set; }
}
