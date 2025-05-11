namespace Example.DataBase;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Indent> Indents { get; set; } = new List<Indent>();
}
