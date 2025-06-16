namespace Wedding_Agency.ViewModels
{
    public class AgencyEmployeeViewModel
    {
        public int IdAgencyEmployee { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string PositionTitle { get; set; } = "";
    }
}
