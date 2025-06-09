using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class WeddingAgencyEmployee
{
    public int Id { get; set; }

    public int? FkContract { get; set; }

    public int? FkAgencyEmployee { get; set; }

    public string? RoleDescription { get; set; }

    public virtual AgencyEmployee? FkAgencyEmployeeNavigation { get; set; }

    public virtual Contract? FkContractNavigation { get; set; }
}
