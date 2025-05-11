namespace Example.DataBase;

public partial class Client
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Indent> Indents { get; set; } = new List<Indent>();
}
