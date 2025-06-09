using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class MenuCatering
{
    public int IdMenuCatering { get; set; }

    public int? FkMenu { get; set; }

    public int? FkCatering { get; set; }

    public string? PortionSize { get; set; }

    public int? CostPerPerson { get; set; }

    public virtual Catering? FkCateringNavigation { get; set; }

    public virtual Menu? FkMenuNavigation { get; set; }
}
