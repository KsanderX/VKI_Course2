namespace Wedding_Agency.Models;

public partial class AgencyEmployee
{
    public int IdAgencyEmployee { get; set; }

    public int? FkPosition { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual Position? FkPositionNavigation { get; set; }

    public virtual ICollection<WeddingAgencyEmployee> WeddingAgencyEmployees { get; set; } = new List<WeddingAgencyEmployee>();
}
