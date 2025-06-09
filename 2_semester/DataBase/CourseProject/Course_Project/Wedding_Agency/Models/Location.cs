using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class Location
{
    public int IdLocation { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? Capacity { get; set; }

    public bool? HasParking { get; set; }

    public bool? IsOutdoor { get; set; }

    public virtual ICollection<BookingLocation> BookingLocations { get; set; } = new List<BookingLocation>();

    public virtual ICollection<DesignLocation> DesignLocations { get; set; } = new List<DesignLocation>();
}
