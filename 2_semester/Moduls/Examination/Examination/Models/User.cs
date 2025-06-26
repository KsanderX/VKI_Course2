namespace Examination.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateOnly RegistrationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Roles Roles { get; set; }
        public int RoleId { get; set; }
        public Car Cars {  get; set; } 
        public int CarId { get; set; }
    }
}
