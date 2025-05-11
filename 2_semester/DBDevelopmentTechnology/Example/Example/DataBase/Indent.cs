namespace Example.DataBase;

public partial class Indent
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? ProductId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Product? Product { get; set; }
}
