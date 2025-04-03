using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Авторы_книги
    {
        [Key]
        public int ID_автора_книги { get; set; }
        public int FKкниги { get; set; }
        [ForeignKey("FKкниги")]
        public Книги Книга { get; set; }
        public int FKавтора { get; set; }
        [ForeignKey("FKавтора")]
        public Авторы Автор { get; set; }
    }
}
