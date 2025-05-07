using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToolRepair.Models;

public partial class AganichevMusicToolsRepairContext : DbContext
{
    public AganichevMusicToolsRepairContext()
    {
    }

    public AganichevMusicToolsRepairContext(DbContextOptions<AganichevMusicToolsRepairContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<CompletedService> CompletedServices { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequiredComponent> RequiredComponents { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Tool> Tools { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DBSRV\\vip2024;DataBase=Aganichev_Music_Tools_repair;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(
                    new Client { IdКлиента = 1, Фио = "Stepan", КонтактныеДанные = "132124910", Логин = "login", Пароль = "parol"},
                    new Client { IdКлиента = 2, Фио = "Vasya", КонтактныеДанные = "13784910", Логин = "vasya", Пароль = "vasya" },
                    new Client { IdКлиента = 3, Фио = "Anastacia", КонтактныеДанные = "187684910", Логин = "log",Пароль = "pass"
                    });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdКлиента).HasName("PK__Clients__F73001116B39A6AD");

            entity.Property(e => e.IdКлиента)
                .ValueGeneratedNever()
                .HasColumnName("ID_Клиента");
            entity.Property(e => e.КонтактныеДанные)
                .HasMaxLength(100)
                .HasColumnName("Контактные_данные");
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<CompletedService>(entity =>
        {
            entity.HasKey(e => e.IdВыполненныхУслуг).HasName("PK__Complete__D0CF1ABFE5347E68");

            entity.Property(e => e.IdВыполненныхУслуг)
                .ValueGeneratedNever()
                .HasColumnName("ID_Выполненных_услуг");
            entity.Property(e => e.FkЗаявки).HasColumnName("FK_Заявки");
            entity.Property(e => e.FkУслуги).HasColumnName("FK_Услуги");

            entity.HasOne(d => d.FkЗаявкиNavigation).WithMany(p => p.CompletedServices)
                .HasForeignKey(d => d.FkЗаявки)
                .HasConstraintName("FK__Completed__FK_За__0C85DE4D");

            entity.HasOne(d => d.FkУслугиNavigation).WithMany(p => p.CompletedServices)
                .HasForeignKey(d => d.FkУслуги)
                .HasConstraintName("FK__Completed__FK_Ус__0B91BA14");
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.IdКомплектующих).HasName("PK__Componen__D47625891FED6EED");

            entity.Property(e => e.IdКомплектующих)
                .ValueGeneratedNever()
                .HasColumnName("ID_Комплектующих");
            entity.Property(e => e.FkПроизводителя).HasColumnName("FK_Производителя");
            entity.Property(e => e.Название).HasMaxLength(100);
            entity.Property(e => e.Описание).HasMaxLength(500);

            entity.HasOne(d => d.IdКомплектующихNavigation).WithOne(p => p.Component)
                .HasForeignKey<Component>(d => d.IdКомплектующих)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Component__ID_Ко__08B54D69");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdРаботника).HasName("PK__Employee__CF37390619C1958F");

            entity.Property(e => e.IdРаботника)
                .ValueGeneratedNever()
                .HasColumnName("ID_Работника");
            entity.Property(e => e.Должность).HasMaxLength(100);
            entity.Property(e => e.КонтактныеДанные)
                .HasMaxLength(100)
                .HasColumnName("Контактные_данные");
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.IdПроизводителя).HasName("PK__Manufact__F0A2A24D50776BAA");

            entity.Property(e => e.IdПроизводителя)
                .ValueGeneratedNever()
                .HasColumnName("ID_Производителя");
            entity.Property(e => e.Название).HasMaxLength(100);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.IdМодели).HasName("PK__Models__4DFD242C54F978BA");

            entity.Property(e => e.IdМодели)
                .ValueGeneratedNever()
                .HasColumnName("ID_Модели");
            entity.Property(e => e.FkВида).HasColumnName("FK_Вида");
            entity.Property(e => e.Название).HasMaxLength(100);

            entity.HasOne(d => d.FkВидаNavigation).WithMany(p => p.Models)
                .HasForeignKey(d => d.FkВида)
                .HasConstraintName("FK__Models__FK_Вида__05D8E0BE");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.IdЗаявки).HasName("PK__Requests__78768B7806983F17");

            entity.Property(e => e.IdЗаявки)
                .ValueGeneratedNever()
                .HasColumnName("ID_Заявки");
            entity.Property(e => e.FkИнструмента).HasColumnName("FK_Инструмента");
            entity.Property(e => e.FkКлиента).HasColumnName("FK_Клиента");
            entity.Property(e => e.FkРаботника).HasColumnName("FK_Работника");
            entity.Property(e => e.FkУслуги).HasColumnName("FK_Услуги");
            entity.Property(e => e.ДатаСоздания)
                .HasColumnType("datetime")
                .HasColumnName("Дата_создания");

            entity.HasOne(d => d.FkИнструментаNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.FkИнструмента)
                .HasConstraintName("FK__Requests__FK_Инс__0E6E26BF");

            entity.HasOne(d => d.FkКлиентаNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.FkКлиента)
                .HasConstraintName("FK__Requests__FK_Кли__10566F31");

            entity.HasOne(d => d.FkРаботникаNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.FkРаботника)
                .HasConstraintName("FK__Requests__FK_Раб__0F624AF8");

            entity.HasOne(d => d.FkУслугиNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.FkУслуги)
                .HasConstraintName("FK__Requests__FK_Усл__0D7A0286");
        });

        modelBuilder.Entity<RequiredComponent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Required__3214EC272F6811F5");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FkКомплектующие).HasColumnName("FK_Комплектующие");
            entity.Property(e => e.FkУслуги).HasColumnName("FK_Услуги");

            entity.HasOne(d => d.FkКомплектующиеNavigation).WithMany(p => p.RequiredComponents)
                .HasForeignKey(d => d.FkКомплектующие)
                .HasConstraintName("FK__RequiredC__FK_Ко__0A9D95DB");

            entity.HasOne(d => d.FkУслугиNavigation).WithMany(p => p.RequiredComponents)
                .HasForeignKey(d => d.FkУслуги)
                .HasConstraintName("FK__RequiredC__FK_Ус__09A971A2");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdУслуги).HasName("PK__Services__C62AED9BBFBFE82C");

            entity.Property(e => e.IdУслуги)
                .ValueGeneratedNever()
                .HasColumnName("ID_Услуги");
            entity.Property(e => e.Название).HasMaxLength(100);
            entity.Property(e => e.Описание).HasMaxLength(500);
        });

        modelBuilder.Entity<Tool>(entity =>
        {
            entity.HasKey(e => e.IdИнструмента).HasName("PK__Tools__F06196735AED36B1");

            entity.Property(e => e.IdИнструмента)
                .ValueGeneratedNever()
                .HasColumnName("ID_Инструмента");
            entity.Property(e => e.FkМодели).HasColumnName("FK_Модели");

            entity.HasOne(d => d.FkМоделиNavigation).WithMany(p => p.Tools)
                .HasForeignKey(d => d.FkМодели)
                .HasConstraintName("FK__Tools__FK_Модели__06CD04F7");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.IdВида).HasName("PK__Types__360C5F9E61EE2BF3");

            entity.Property(e => e.IdВида)
                .ValueGeneratedNever()
                .HasColumnName("ID_Вида");
            entity.Property(e => e.Название).HasMaxLength(100);
            entity.Property(e => e.Описание).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
