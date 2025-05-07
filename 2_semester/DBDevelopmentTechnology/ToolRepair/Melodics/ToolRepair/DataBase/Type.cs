using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class Type
{
    public int IdВида { get; set; }

    public string? Название { get; set; }

    public string? Описание { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
