using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? PassportData { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
