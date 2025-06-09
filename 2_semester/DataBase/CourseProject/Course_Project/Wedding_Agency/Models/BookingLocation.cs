using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class BookingLocation
{
    public int IdBookingLocation { get; set; }

    public int? FkContract { get; set; }

    public int? FkLocation { get; set; }

    public DateOnly? BookingDate { get; set; }

    public TimeOnly? TimeFrom { get; set; }

    public TimeOnly? TimeTo { get; set; }

    public int? TotalCost { get; set; }

    public virtual Contract? FkContractNavigation { get; set; }

    public virtual Location? FkLocationNavigation { get; set; }
}
