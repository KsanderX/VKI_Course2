using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class PositionFreelanceEmployee
{
    public int IdPositionFreelanceEmployees { get; set; }

    public string? Title { get; set; }

    public string? Responsibilities { get; set; }

    public virtual ICollection<FreelanceEmployee> FreelanceEmployees { get; set; } = new List<FreelanceEmployee>();
}
