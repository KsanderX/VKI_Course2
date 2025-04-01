using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Жанры_книги
    {
        [Key]
        public int ID_жанра_книги { get; set; }
        public int FKкниги { get; set; }
        [ForeignKey("FKкниги")]
        public Книги Книга { get; set; }
        public int FKжанра { get; set; }
        [ForeignKey("FKжанра")]
        public Жанры Жанр { get; set; }
    }
}
