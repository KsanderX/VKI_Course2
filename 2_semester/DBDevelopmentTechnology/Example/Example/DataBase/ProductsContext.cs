using Microsoft.EntityFrameworkCore;

namespace Example.DataBase;

public partial class ProductsContext : DbContext
{
    public ProductsContext()
    {
    }

    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Indent> Indents { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=PC_SANYA;Database=Products;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC0794059643");

            entity.ToTable("Client");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Indent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Indent__3214EC0715474C0B");

            entity.ToTable("Indent");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Client).WithMany(p => p.Indents)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Indent__ClientId__3B75D760");

            entity.HasOne(d => d.Product).WithMany(p => p.Indents)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Indent__ProductI__3C69FB99");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC076138E9E4");

            entity.ToTable("Product");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
