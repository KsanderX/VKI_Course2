using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Издательства
    {
        [Key]
        public int ID_издательства { get; set; }
        public ICollection<Издательства_книги> Издательства_книги { get; set; }
    }
}
