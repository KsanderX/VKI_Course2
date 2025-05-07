using System;
using System.Collections.Generic;

namespace ToolRepair.Models;

public partial class Employee
{
    public int IdРаботника { get; set; }

    public string? Фио { get; set; }

    public string? КонтактныеДанные { get; set; }

    public string? Должность { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
