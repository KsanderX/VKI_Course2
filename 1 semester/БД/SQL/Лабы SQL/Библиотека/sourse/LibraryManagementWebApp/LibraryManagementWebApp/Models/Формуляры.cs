using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Формуляры
    {
        [Key]
        public int ID_формуляра { get; set; }
        public string Дата_операции { get; set; }
        public string Сроки_пользования { get; set; }
        public int FKэкземпляра_книги { get; set; }
        [ForeignKey("FKэкземпляра_книги")]
        public Экземпляры_книги Экземпляр_книги { get; set; }
        public int FKчитателя { get; set; }
        [ForeignKey("FKчитателя")]
        public Читатели Читатель { get; set; }
    }
}
