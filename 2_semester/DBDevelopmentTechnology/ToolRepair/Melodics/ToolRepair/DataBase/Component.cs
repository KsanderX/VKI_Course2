using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class Component
{
    public int IdКомплектующих { get; set; }

    public string? Название { get; set; }

    public string? Описание { get; set; }

    public int? FkПроизводителя { get; set; }

    public virtual Manufacturer IdКомплектующихNavigation { get; set; } = null!;

    public virtual ICollection<RequiredComponent> RequiredComponents { get; set; } = new List<RequiredComponent>();
}
