using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class CateringEmployee
{
    public int Id { get; set; }

    public int? FkCatering { get; set; }

    public int? FkFreelanceEmployee { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Role { get; set; }

    public virtual Catering? FkCateringNavigation { get; set; }

    public virtual FreelanceEmployee? FkFreelanceEmployeeNavigation { get; set; }
}
