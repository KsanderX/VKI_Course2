using System;
using System.Collections.Generic;

namespace LibraryManagement.Models;

public partial class Авторы
{
    public int IdАвтора { get; set; }
    public string? Имя { get; set; }

    public virtual ICollection<АвторыКниги> АвторыКнигиs { get; set; } = new List<АвторыКниги>();
}
