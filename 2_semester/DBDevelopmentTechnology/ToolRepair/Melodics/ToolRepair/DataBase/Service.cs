using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class Service
{
    public int IdУслуги { get; set; }

    public string? Название { get; set; }

    public string? Описание { get; set; }

    public virtual ICollection<CompletedService> CompletedServices { get; set; } = new List<CompletedService>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<RequiredComponent> RequiredComponents { get; set; } = new List<RequiredComponent>();
}
