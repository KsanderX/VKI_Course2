using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class Client
{
    public int IdКлиента { get; set; }

    public string? Фио { get; set; }

    public string? КонтактныеДанные { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
