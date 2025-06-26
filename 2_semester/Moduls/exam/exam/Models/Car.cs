using exam.Models;

namespace exam.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? VIN { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public string Description { get; set; }
        public DateOnly PublicationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public CarStatus Status { get; set; }
        public int? UserId { get; set; } 
        public User? User { get; set; } // Навигационное свойство для связи с пользователем

    }
    public enum CarStatus
    {
        InStock, //В наличии
        Issuid, //выдана
        На_Обслуживании
    } 
}
