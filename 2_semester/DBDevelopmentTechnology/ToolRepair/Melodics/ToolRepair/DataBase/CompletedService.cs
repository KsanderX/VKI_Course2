using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class CompletedService
{
    public int IdВыполненныхУслуг { get; set; }

    public int? FkУслуги { get; set; }

    public int? FkЗаявки { get; set; }

    public virtual Request? FkЗаявкиNavigation { get; set; }

    public virtual Service? FkУслугиNavigation { get; set; }
}
