using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Экземпляры_книги
    {
        [Key]
        public int ID_экземпляра_книги { get; set; }
        public int FKкниги { get; set; }
        [ForeignKey("FKкниги")]
        public Книги Книга { get; set; }
        public int FKячейки { get; set; }
        [ForeignKey("FKячейки")]
        public Ячейки Ячейка { get; set; }
        public ICollection<Формуляры> Формуляры { get; set; }
    }
}
