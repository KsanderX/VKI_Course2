using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Секции
    {
        [Key]
        public int ID_секции { get; set; }
        public int FKкомнаты { get; set; }
        [ForeignKey("FKкомнаты")]
        public Комнаты Комната { get; set; }
        public ICollection<Ряды> Ряды { get; set; }
    }
}
