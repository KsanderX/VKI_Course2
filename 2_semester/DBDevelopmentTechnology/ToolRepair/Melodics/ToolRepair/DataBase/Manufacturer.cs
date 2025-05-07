using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class Manufacturer
{
    public int IdПроизводителя { get; set; }

    public string? Название { get; set; }

    public virtual Component? Component { get; set; }
}
