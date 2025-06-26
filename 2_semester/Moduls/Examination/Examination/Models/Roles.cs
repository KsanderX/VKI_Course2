namespace Examination.Models
{
    public class Roles
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string AccessRights { get; set; } // права доступа
        public List<User> Users { get; set; }
    }
}
