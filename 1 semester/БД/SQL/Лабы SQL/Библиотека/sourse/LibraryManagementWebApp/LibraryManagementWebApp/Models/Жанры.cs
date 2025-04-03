using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Жанры
    {
        [Key]
        public int ID_жанра { get; set; }
        public ICollection<Жанры_книги> Жанры_книги { get; set; }
    }
}
