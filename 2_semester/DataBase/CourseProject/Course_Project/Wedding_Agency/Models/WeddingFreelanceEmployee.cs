using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class WeddingFreelanceEmployee
{
    public int Id { get; set; }

    public int? FkContract { get; set; }

    public int? FkFreelanceEmployee { get; set; }

    public string? RoleDescription { get; set; }

    public virtual Contract? FkContractNavigation { get; set; }

    public virtual FreelanceEmployee? FkFreelanceEmployeeNavigation { get; set; }
}
