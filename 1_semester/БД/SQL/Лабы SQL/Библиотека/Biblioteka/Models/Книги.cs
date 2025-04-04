using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class Книги
{
    public int IdКниги { get; set; }

    public virtual ICollection<АвторыКниги> АвторыКнигиs { get; set; } = new List<АвторыКниги>();

    public virtual ICollection<ЖанрыКниги> ЖанрыКнигиs { get; set; } = new List<ЖанрыКниги>();

    public virtual ICollection<ИздательстваКниги> ИздательстваКнигиs { get; set; } = new List<ИздательстваКниги>();

    public virtual ICollection<ПопулярныеКниги> ПопулярныеКнигиs { get; set; } = new List<ПопулярныеКниги>();

    public virtual ICollection<ЭкземплярыКниги> ЭкземплярыКнигиs { get; set; } = new List<ЭкземплярыКниги>();
}
