using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Издательства_книги
    {
        [Key]
        public int ID_издательства { get; set; }
        public int FKкниги { get; set; }
        [ForeignKey("FKкниги")]
        public Книги Книга { get; set; }
        public int FKиздательства { get; set; }
        [ForeignKey("FKиздательства")]
        public Издательства Издательство { get; set; }
    }
}
