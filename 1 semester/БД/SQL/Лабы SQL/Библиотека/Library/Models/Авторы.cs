using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Авторы
{
    public int IdАвтора { get; set; }

    public virtual ICollection<АвторыКниги> АвторыКнигиs { get; set; } = new List<АвторыКниги>();
}
