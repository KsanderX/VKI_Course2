using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wedding_Agency.Models;

public partial class WeddingAgencyContext : DbContext
{
    public WeddingAgencyContext()
    {
    }

    public WeddingAgencyContext(DbContextOptions<WeddingAgencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgencyEmployee> AgencyEmployees { get; set; }

    public virtual DbSet<BookingLocation> BookingLocations { get; set; }

    public virtual DbSet<Catering> Caterings { get; set; }

    public virtual DbSet<CateringEmployee> CateringEmployees { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Decoration> Decorations { get; set; }

    public virtual DbSet<DesignLocation> DesignLocations { get; set; }

    public virtual DbSet<FreelanceEmployee> FreelanceEmployees { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuCatering> MenuCaterings { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PositionFreelanceEmployee> PositionFreelanceEmployees { get; set; }

    public virtual DbSet<WeddingAgencyEmployee> WeddingAgencyEmployees { get; set; }

    public virtual DbSet<WeddingFreelanceEmployee> WeddingFreelanceEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=PC_SANYA;Database=Wedding_Agency;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgencyEmployee>(entity =>
        {
            entity.HasKey(e => e.IdAgencyEmployee).HasName("PK__Agency_E__91F2FB189089A29F");

            entity.ToTable("Agency_Employee");

            entity.Property(e => e.IdAgencyEmployee).HasColumnName("Id_Agency_Employee");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.FkPosition).HasColumnName("FK_Position");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Login).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.FkPositionNavigation).WithMany(p => p.AgencyEmployees)
                .HasForeignKey(d => d.FkPosition)
                .HasConstraintName("FK__Agency_Em__FK_Po__59063A47");
        });

        modelBuilder.Entity<BookingLocation>(entity =>
        {
            entity.HasKey(e => e.IdBookingLocation).HasName("PK__Booking___C0517DC535382286");

            entity.ToTable("Booking_Location");

            entity.Property(e => e.IdBookingLocation).HasColumnName("Id_Booking_Location");
            entity.Property(e => e.FkContract).HasColumnName("FK_Contract");
            entity.Property(e => e.FkLocation).HasColumnName("FK_Location");

            entity.HasOne(d => d.FkContractNavigation).WithMany(p => p.BookingLocations)
                .HasForeignKey(d => d.FkContract)
                .HasConstraintName("FK__Booking_L__FK_Lo__5CD6CB2B");

            entity.HasOne(d => d.FkLocationNavigation).WithMany(p => p.BookingLocations)
                .HasForeignKey(d => d.FkLocation)
                .HasConstraintName("FK__Booking_L__FK_Lo__5DCAEF64");
        });

        modelBuilder.Entity<Catering>(entity =>
        {
            entity.HasKey(e => e.IdCatering).HasName("PK__Catering__FB15DC14E606FCD2");

            entity.ToTable("Catering");

            entity.Property(e => e.IdCatering).HasColumnName("Id_Catering");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FkContract).HasColumnName("FK_Contract");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.FkContractNavigation).WithMany(p => p.Caterings)
                .HasForeignKey(d => d.FkContract)
                .HasConstraintName("FK__Catering__FK_Con__6383C8BA");
        });

        modelBuilder.Entity<CateringEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Catering__3214EC07C4CC2850");

            entity.ToTable("Catering_Employee");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.FkCatering).HasColumnName("FK_Catering");
            entity.Property(e => e.FkFreelanceEmployee).HasColumnName("FK_Freelance_Employee");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkCateringNavigation).WithMany(p => p.CateringEmployees)
                .HasForeignKey(d => d.FkCatering)
                .HasConstraintName("FK__Catering___FK_Fr__619B8048");

            entity.HasOne(d => d.FkFreelanceEmployeeNavigation).WithMany(p => p.CateringEmployees)
                .HasForeignKey(d => d.FkFreelanceEmployee)
                .HasConstraintName("FK__Catering___FK_Fr__628FA481");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Client__668DFF3F6D7AB22F");

            entity.ToTable("Client");

            entity.Property(e => e.IdClient).HasColumnName("Id_Client");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.PassportData)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.IdContract).HasName("PK__Contract__400CCC872F70A6B2");

            entity.ToTable("Contract");

            entity.Property(e => e.IdContract).HasColumnName("Id_Contract");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FkClient).HasColumnName("FK_Client");

            entity.HasOne(d => d.FkClientNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.FkClient)
                .HasConstraintName("FK__Contract__FK_Cli__5629CD9C");
        });

        modelBuilder.Entity<Decoration>(entity =>
        {
            entity.HasKey(e => e.IdDecoration).HasName("PK__Decorati__2E0C8D8E1F59BE09");

            entity.ToTable("Decoration");

            entity.Property(e => e.IdDecoration).HasColumnName("Id_Decoration");
            entity.Property(e => e.ColorTheme)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FkDesignLocation).HasColumnName("FK_Design_Location");
            entity.Property(e => e.Material)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkDesignLocationNavigation).WithMany(p => p.Decorations)
                .HasForeignKey(d => d.FkDesignLocation)
                .HasConstraintName("FK__Decoratio__FK_De__5FB337D6");
        });

        modelBuilder.Entity<DesignLocation>(entity =>
        {
            entity.HasKey(e => e.IdDesignLocation).HasName("PK__Design_L__EB276848EA28145A");

            entity.ToTable("Design_Location");

            entity.Property(e => e.IdDesignLocation).HasColumnName("Id_Design_Location");
            entity.Property(e => e.ColorScheme)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FkLocation).HasColumnName("FK_Location");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Style)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.FkLocationNavigation).WithMany(p => p.DesignLocations)
                .HasForeignKey(d => d.FkLocation)
                .HasConstraintName("FK__Design_Lo__FK_Lo__5EBF139D");
        });

        modelBuilder.Entity<FreelanceEmployee>(entity =>
        {
            entity.HasKey(e => e.IdFreelanceEmployee).HasName("PK__Freelanc__E57F533E9511D4C6");

            entity.ToTable("Freelance_Employee");

            entity.Property(e => e.IdFreelanceEmployee).HasColumnName("Id_Freelance_Employee");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.FkDecoration).HasColumnName("FK_Decoration");
            entity.Property(e => e.FkDesignLocation).HasColumnName("FK_Design_Location");
            entity.Property(e => e.FkPosition).HasColumnName("FK_Position");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.FkDesignLocationNavigation).WithMany(p => p.FreelanceEmployees)
                .HasForeignKey(d => d.FkDesignLocation)
                .HasConstraintName("FK__Freelance__FK_De__02084FDA");

            entity.HasOne(d => d.FkPositionNavigation).WithMany(p => p.FreelanceEmployees)
                .HasForeignKey(d => d.FkPosition)
                .HasConstraintName("FK__Freelance__FK_Po__5BE2A6F2");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.IdLocation).HasName("PK__Location__F5E05EB7D7C3EA7F");

            entity.ToTable("Location");

            entity.Property(e => e.IdLocation).HasColumnName("Id_Location");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__F6BCBF2ED5C82F3E");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("Id_Menu");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MenuCatering>(entity =>
        {
            entity.HasKey(e => e.IdMenuCatering).HasName("PK__Menu_Cat__3E1B0FE568A39B47");

            entity.ToTable("Menu_Catering");

            entity.Property(e => e.IdMenuCatering).HasColumnName("Id_Menu_Catering");
            entity.Property(e => e.FkCatering).HasColumnName("FK_Catering");
            entity.Property(e => e.FkMenu).HasColumnName("FK_Menu");
            entity.Property(e => e.PortionSize)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkCateringNavigation).WithMany(p => p.MenuCaterings)
                .HasForeignKey(d => d.FkCatering)
                .HasConstraintName("FK__Menu_Cate__FK_Ca__656C112C");

            entity.HasOne(d => d.FkMenuNavigation).WithMany(p => p.MenuCaterings)
                .HasForeignKey(d => d.FkMenu)
                .HasConstraintName("FK__Menu_Cate__FK_Ca__6477ECF3");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("PK__Position__D2521D5761320C10");

            entity.ToTable("Position");

            entity.Property(e => e.IdPosition).HasColumnName("Id_Position");
            entity.Property(e => e.Responsibilities)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PositionFreelanceEmployee>(entity =>
        {
            entity.HasKey(e => e.IdPositionFreelanceEmployees).HasName("PK__Position__3E5CCB0580A3C9B2");

            entity.ToTable("Position_Freelance_Employees");

            entity.Property(e => e.IdPositionFreelanceEmployees).HasColumnName("Id_Position_Freelance_Employees");
            entity.Property(e => e.Responsibilities)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WeddingAgencyEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wedding___3214EC0769763389");

            entity.ToTable("Wedding_Agency_Employee");

            entity.Property(e => e.FkAgencyEmployee).HasColumnName("FK_Agency_Employee");
            entity.Property(e => e.FkContract).HasColumnName("FK_Contract");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.FkAgencyEmployeeNavigation).WithMany(p => p.WeddingAgencyEmployees)
                .HasForeignKey(d => d.FkAgencyEmployee)
                .HasConstraintName("FK__Wedding_A__FK_Ag__5812160E");

            entity.HasOne(d => d.FkContractNavigation).WithMany(p => p.WeddingAgencyEmployees)
                .HasForeignKey(d => d.FkContract)
                .HasConstraintName("FK__Wedding_A__FK_Ag__571DF1D5");
        });

        modelBuilder.Entity<WeddingFreelanceEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wedding___3214EC07842E25C6");

            entity.ToTable("Wedding_Freelance_Employee");

            entity.Property(e => e.FkContract).HasColumnName("FK_Contract");
            entity.Property(e => e.FkFreelanceEmployee).HasColumnName("FK_Freelance_Employee");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.FkContractNavigation).WithMany(p => p.WeddingFreelanceEmployees)
                .HasForeignKey(d => d.FkContract)
                .HasConstraintName("FK__Wedding_F__FK_Fr__59FA5E80");

            entity.HasOne(d => d.FkFreelanceEmployeeNavigation).WithMany(p => p.WeddingFreelanceEmployees)
                .HasForeignKey(d => d.FkFreelanceEmployee)
                .HasConstraintName("FK__Wedding_F__FK_Fr__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
