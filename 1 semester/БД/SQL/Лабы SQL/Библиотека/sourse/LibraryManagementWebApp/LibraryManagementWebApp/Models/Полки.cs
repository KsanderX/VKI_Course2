using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Полки
    {
        [Key]
        public int ID_полки { get; set; }
        public int FKряда { get; set; }
        [ForeignKey("FKряда")]
        public Ряды Ряд { get; set; }
        public ICollection<Ячейки> Ячейки { get; set; }
    }
}
