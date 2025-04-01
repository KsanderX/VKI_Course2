using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Ячейки
    {
        [Key]
        public int ID_ячейки { get; set; }
        public int FKполки { get; set; }
        [ForeignKey("FKполки")]
        public Полки Полка { get; set; }
        public ICollection<Экземпляры_книги> Экземпляры_книги { get; set; }
    }
}
