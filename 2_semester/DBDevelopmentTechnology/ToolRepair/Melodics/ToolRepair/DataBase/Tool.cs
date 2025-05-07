using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class Tool
{
    public int IdИнструмента { get; set; }

    public int? FkМодели { get; set; }

    public virtual Model? FkМоделиNavigation { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
