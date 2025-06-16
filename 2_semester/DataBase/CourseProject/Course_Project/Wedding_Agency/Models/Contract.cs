namespace Wedding_Agency.Models;

public partial class Contract
{
    public int IdContract { get; set; }

    public int? FkClient { get; set; }

    public DateOnly? ContractDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public DateOnly? WeddingDate { get; set; }

    public TimeOnly? WeddingTime { get; set; }

    public int? TotalBudget { get; set; }

    public int? PrepaymentAmount { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<BookingLocation> BookingLocations { get; set; } = new List<BookingLocation>();

    public virtual ICollection<Catering> Caterings { get; set; } = new List<Catering>();

    public virtual Client? FkClientNavigation { get; set; }

    public virtual ICollection<WeddingAgencyEmployee> WeddingAgencyEmployees { get; set; } = new List<WeddingAgencyEmployee>();

    public virtual ICollection<WeddingFreelanceEmployee> WeddingFreelanceEmployees { get; set; } = new List<WeddingFreelanceEmployee>();
}
