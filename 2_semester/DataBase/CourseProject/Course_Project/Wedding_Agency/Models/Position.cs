using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class Position
{
    public int IdPosition { get; set; }

    public string? Title { get; set; }

    public string? Responsibilities { get; set; }

    public virtual ICollection<AgencyEmployee> AgencyEmployees { get; set; } = new List<AgencyEmployee>();
}
