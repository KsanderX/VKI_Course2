using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class Издательства
{
    public int IdИздательства { get; set; }

    public virtual ICollection<ИздательстваКниги> ИздательстваКнигиs { get; set; } = new List<ИздательстваКниги>();
}
