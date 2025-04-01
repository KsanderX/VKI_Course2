using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Книги
    {
        [Key]
        public int ID_книги { get; set; }
        public ICollection<Экземпляры_книги> Экземпляры_книги { get; set; }
        public ICollection<Авторы_книги> Авторы_книги { get; set; }
        public ICollection<Жанры_книги> Жанры_книги { get; set; }
        public ICollection<Издательства_книги> Издательства_книги { get; set; }
    }
}
