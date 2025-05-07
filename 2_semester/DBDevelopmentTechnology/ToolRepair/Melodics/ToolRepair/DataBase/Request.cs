using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class Request
{
    public int IdЗаявки { get; set; }

    public int? FkКлиента { get; set; }

    public int? FkРаботника { get; set; }

    public int? FkИнструмента { get; set; }

    public int? FkУслуги { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    public virtual ICollection<CompletedService> CompletedServices { get; set; } = new List<CompletedService>();

    public virtual Tool? FkИнструментаNavigation { get; set; }

    public virtual Client? FkКлиентаNavigation { get; set; }

    public virtual Employee? FkРаботникаNavigation { get; set; }

    public virtual Service? FkУслугиNavigation { get; set; }
}
