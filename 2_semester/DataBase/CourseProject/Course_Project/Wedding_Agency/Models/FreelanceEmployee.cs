using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class FreelanceEmployee
{
    public int IdFreelanceEmployee { get; set; }

    public int? FkPosition { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int? FkDecoration { get; set; }

    public int? FkDesignLocation { get; set; }

    public virtual ICollection<CateringEmployee> CateringEmployees { get; set; } = new List<CateringEmployee>();

    public virtual DesignLocation? FkDesignLocationNavigation { get; set; }

    public virtual PositionFreelanceEmployee? FkPositionNavigation { get; set; }

    public virtual ICollection<WeddingFreelanceEmployee> WeddingFreelanceEmployees { get; set; } = new List<WeddingFreelanceEmployee>();
}
