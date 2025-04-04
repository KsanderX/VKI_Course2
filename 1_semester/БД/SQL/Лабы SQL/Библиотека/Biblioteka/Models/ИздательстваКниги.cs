using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class ИздательстваКниги
{
    public int IdИздательстваКниги { get; set; }

    public int? Fkкниги { get; set; }

    public int? Fkиздательства { get; set; }

    public virtual Издательства? FkиздательстваNavigation { get; set; }

    public virtual Книги? FkкнигиNavigation { get; set; }
}
