using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Ряды
    {
        [Key]
        public int ID_ряда { get; set; }
        public int FKсекции { get; set; }
        [ForeignKey("FKсекции")]
        public Секции Секция { get; set; }
        public ICollection<Полки> Полки { get; set; }
    }
}
