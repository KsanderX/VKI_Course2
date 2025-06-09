using System;
using System.Collections.Generic;

namespace Wedding_Agency.Models;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<MenuCatering> MenuCaterings { get; set; } = new List<MenuCatering>();
}
