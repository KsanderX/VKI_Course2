using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class Decoration
{
    public int IdDecoration { get; set; }

    public int? FkDesignLocation { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Material { get; set; }

    public string? ColorTheme { get; set; }

    public virtual DesignLocation? FkDesignLocationNavigation { get; set; }
}
