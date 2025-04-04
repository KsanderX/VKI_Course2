using System;
using System.Collections.Generic;

namespace LibraryManagement.Models;

public partial class Издательства
{
    public int IdИздательства { get; set; }
    public string? Название { get; set; }

    public virtual ICollection<ИздательстваКниги> ИздательстваКнигиs { get; set; } = new List<ИздательстваКниги>();
}
