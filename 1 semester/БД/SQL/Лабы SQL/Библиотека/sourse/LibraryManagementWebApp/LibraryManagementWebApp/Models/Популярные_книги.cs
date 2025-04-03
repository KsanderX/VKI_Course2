using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Популярные_книги
    {
        [Key]
        public int ID_популярной_книги { get; set; }
        public int FKкниги { get; set; }
        [ForeignKey("FKкниги")]
        public Книги Книга { get; set; }
    }
}
