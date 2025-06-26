namespace exam.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string AccessRights { get; set; } // права доступа
        List<User> Users { get; set; } = new List<User>(); //внеш ключ
    }
}
