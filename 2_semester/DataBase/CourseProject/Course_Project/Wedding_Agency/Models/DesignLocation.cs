using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class DesignLocation
{
    public int IdDesignLocation { get; set; }

    public int? FkLocation { get; set; }

    public string? Style { get; set; }

    public string? ColorScheme { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Decoration> Decorations { get; set; } = new List<Decoration>();

    public virtual ICollection<Decorator> Decorators { get; set; } = new List<Decorator>();

    public virtual Location? FkLocationNavigation { get; set; }
}
