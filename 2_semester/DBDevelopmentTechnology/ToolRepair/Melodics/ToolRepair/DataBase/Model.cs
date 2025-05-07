using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class Model
{
    public int IdМодели { get; set; }

    public string? Название { get; set; }

    public int? FkВида { get; set; }

    public virtual Type? FkВидаNavigation { get; set; }

    public virtual ICollection<Tool> Tools { get; set; } = new List<Tool>();
}
