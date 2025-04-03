using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Издательства
{
    public int IdИздательства { get; set; }

    public virtual ICollection<ИздательстваКниги> ИздательстваКнигиs { get; set; } = new List<ИздательстваКниги>();
}
