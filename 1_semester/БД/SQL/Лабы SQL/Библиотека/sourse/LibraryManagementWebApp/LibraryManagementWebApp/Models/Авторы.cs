using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Авторы
    {
        [Key]
        public int ID_автора { get; set; }
        public ICollection<Авторы_книги> Авторы_книги { get; set; }
    }
}
