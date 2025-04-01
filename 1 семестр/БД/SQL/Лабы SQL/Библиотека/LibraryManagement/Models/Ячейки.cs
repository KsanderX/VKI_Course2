using System;
using System.Collections.Generic;

namespace LibraryManagement.Models;

public partial class Ячейки
{
    public int IdЯчейки { get; set; }

    public int? Fkячейки { get; set; }

    public virtual Полки? FkячейкиNavigation { get; set; }

    public virtual ICollection<ЭкземплярыКниги> ЭкземплярыКнигиs { get; set; } = new List<ЭкземплярыКниги>();
}
