using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class Decorator
{
    public int IdDecorator { get; set; }

    public int? FkDesignLocation { get; set; }

    public int? FkFreelanceEmployee { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Specialty { get; set; }

    public virtual DesignLocation? FkDesignLocationNavigation { get; set; }

    public virtual FreelanceEmployee? FkFreelanceEmployeeNavigation { get; set; }
}
