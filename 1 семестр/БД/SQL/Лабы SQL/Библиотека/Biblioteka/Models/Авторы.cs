using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class Авторы
{
    public int IdАвтора { get; set; }

    public virtual ICollection<АвторыКниги> АвторыКнигиs { get; set; } = new List<АвторыКниги>();
}
