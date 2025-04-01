using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Комнаты
    {
        [Key]
        public int ID_комнаты { get; set; }
        public ICollection<Секции> Секции { get; set; }
    }
}
