using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class Catering
{
    public int IdCatering { get; set; }

    public int? FkContract { get; set; }

    public string? CompanyName { get; set; }

    public string? ContactPerson { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<CateringEmployee> CateringEmployees { get; set; } = new List<CateringEmployee>();

    public virtual Contract? FkContractNavigation { get; set; }

    public virtual ICollection<MenuCatering> MenuCaterings { get; set; } = new List<MenuCatering>();
}
