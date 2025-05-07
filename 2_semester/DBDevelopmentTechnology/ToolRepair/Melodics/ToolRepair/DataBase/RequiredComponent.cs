using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class RequiredComponent
{
    public int Id { get; set; }

    public int? FkУслуги { get; set; }

    public int? FkКомплектующие { get; set; }

    public virtual Component? FkКомплектующиеNavigation { get; set; }

    public virtual Service? FkУслугиNavigation { get; set; }
}
