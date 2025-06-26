using exam.Models;

namespace exam.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public int? UserId { get; set; } 
        public User? User { get; set; } // Навигационное свойство для связи с пользователем
        public DateTime CreatedAt { get; set; }

    }
    public enum RequestStatus
    {
        InProgress,
        Completed
    }
}
