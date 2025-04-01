using System;
using System.Collections.Generic;

namespace Biblioteka.Models;

public partial class Формуляры
{
    public int IdФормуляра { get; set; }

    public string? ДатаОперации { get; set; }

    public string? СрокиПользования { get; set; }

    public int? Fkсотрудника { get; set; }

    public int? Fkоперации { get; set; }

    public int? FkэкземпляраКниги { get; set; }

    public int? Fkчитателя { get; set; }

    public virtual СправочникОпераций? FkоперацииNavigation { get; set; }

    public virtual СотрудникиБиблиотеки? FkсотрудникаNavigation { get; set; }

    public virtual Читатели? FkчитателяNavigation { get; set; }

    public virtual ЭкземплярыКниги? FkэкземпляраКнигиNavigation { get; set; }
}
