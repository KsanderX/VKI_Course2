using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Читатели
    {
        [Key]
        public int ID_читателя { get; set; }
        public string Читательский_билет { get; set; }
        public ICollection<Формуляры> Формуляры { get; set; }
    }
}
