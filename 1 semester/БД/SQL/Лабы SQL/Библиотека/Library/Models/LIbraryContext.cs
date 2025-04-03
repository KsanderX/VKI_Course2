using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public partial class LIbraryContext : DbContext
{
    public LIbraryContext()
    {
    }

    public LIbraryContext(DbContextOptions<LIbraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Авторы> Авторыs { get; set; }

    public virtual DbSet<АвторыКниги> АвторыКнигиs { get; set; }

    public virtual DbSet<Жанры> Жанрыs { get; set; }

    public virtual DbSet<ЖанрыКниги> ЖанрыКнигиs { get; set; }

    public virtual DbSet<Издательства> Издательстваs { get; set; }

    public virtual DbSet<ИздательстваКниги> ИздательстваКнигиs { get; set; }

    public virtual DbSet<Книги> Книгиs { get; set; }

    public virtual DbSet<Комнаты> Комнатыs { get; set; }

    public virtual DbSet<Полки> Полкиs { get; set; }

    public virtual DbSet<ПопулярныеКниги> ПопулярныеКнигиs { get; set; }

    public virtual DbSet<Ряды> Рядыs { get; set; }

    public virtual DbSet<Секции> Секцииs { get; set; }

    public virtual DbSet<СотрудникиБиблиотеки> СотрудникиБиблиотекиs { get; set; }

    public virtual DbSet<СправочникОпераций> СправочникОперацийs { get; set; }

    public virtual DbSet<Формуляры> Формулярыs { get; set; }

    public virtual DbSet<Читатели> Читателиs { get; set; }

    public virtual DbSet<ЭкземплярыКниги> ЭкземплярыКнигиs { get; set; }

    public virtual DbSet<Ячейки> Ячейкиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DBSRV\\vip2024;Database=Аганичев_Библиотека;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Авторы>(entity =>
        {
            entity.HasKey(e => e.IdАвтора).HasName("PK__Авторы__FCFCC9B5B322984F");

            entity.ToTable("Авторы");

            entity.Property(e => e.IdАвтора).HasColumnName("ID_автора");
        });

        modelBuilder.Entity<АвторыКниги>(entity =>
        {
            entity.HasKey(e => e.IdАвтораКниги).HasName("PK__Авторы_к__A9AAB8629D8E0D26");

            entity.ToTable("Авторы_книги");

            entity.Property(e => e.IdАвтораКниги).HasColumnName("ID_автора_книги");
            entity.Property(e => e.Fkавтора).HasColumnName("FKавтора");
            entity.Property(e => e.Fkкниги).HasColumnName("FKкниги");

            entity.HasOne(d => d.FkавтораNavigation).WithMany(p => p.АвторыКнигиs)
                .HasForeignKey(d => d.Fkавтора)
                .HasConstraintName("FK__Авторы_кн__FKавт__6B24EA82");

            entity.HasOne(d => d.FkкнигиNavigation).WithMany(p => p.АвторыКнигиs)
                .HasForeignKey(d => d.Fkкниги)
                .HasConstraintName("FK__Авторы_кн__FKкни__6A30C649");
        });

        modelBuilder.Entity<Жанры>(entity =>
        {
            entity.HasKey(e => e.IdЖанра).HasName("PK__Жанры__2A5F7E358046D24B");

            entity.ToTable("Жанры");

            entity.Property(e => e.IdЖанра).HasColumnName("ID_жанра");
        });

        modelBuilder.Entity<ЖанрыКниги>(entity =>
        {
            entity.HasKey(e => e.IdЖанраКниги).HasName("PK__Жанры_кн__0C1D872C853DBD77");

            entity.ToTable("Жанры_книги");

            entity.Property(e => e.IdЖанраКниги).HasColumnName("ID_жанра_книги");
            entity.Property(e => e.Fkжанра).HasColumnName("FKжанра");
            entity.Property(e => e.Fkкниги).HasColumnName("FKкниги");

            entity.HasOne(d => d.FkжанраNavigation).WithMany(p => p.ЖанрыКнигиs)
                .HasForeignKey(d => d.Fkжанра)
                .HasConstraintName("FK__Жанры_кни__FKжан__6D0D32F4");

            entity.HasOne(d => d.FkкнигиNavigation).WithMany(p => p.ЖанрыКнигиs)
                .HasForeignKey(d => d.Fkкниги)
                .HasConstraintName("FK__Жанры_кни__FKкни__6C190EBB");
        });

        modelBuilder.Entity<Издательства>(entity =>
        {
            entity.HasKey(e => e.IdИздательства).HasName("PK__Издатель__3A9FAA8B7CCD8B90");

            entity.ToTable("Издательства");

            entity.Property(e => e.IdИздательства).HasColumnName("ID_издательства");
        });

        modelBuilder.Entity<ИздательстваКниги>(entity =>
        {
            entity.HasKey(e => e.IdИздательстваКниги).HasName("PK__Издатель__BFA4F1E064663DF3");

            entity.ToTable("Издательства_книги");

            entity.Property(e => e.IdИздательстваКниги).HasColumnName("ID_издательства_книги");
            entity.Property(e => e.Fkиздательства).HasColumnName("FKиздательства");
            entity.Property(e => e.Fkкниги).HasColumnName("FKкниги");

            entity.HasOne(d => d.FkиздательстваNavigation).WithMany(p => p.ИздательстваКнигиs)
                .HasForeignKey(d => d.Fkиздательства)
                .HasConstraintName("FK__Издательс__FKизд__6EF57B66");

            entity.HasOne(d => d.FkкнигиNavigation).WithMany(p => p.ИздательстваКнигиs)
                .HasForeignKey(d => d.Fkкниги)
                .HasConstraintName("FK__Издательс__FKкни__6E01572D");
        });

        modelBuilder.Entity<Книги>(entity =>
        {
            entity.HasKey(e => e.IdКниги).HasName("PK__Книги__7AC6E889DC57B72D");

            entity.ToTable("Книги");

            entity.Property(e => e.IdКниги).HasColumnName("ID_книги");
        });

        modelBuilder.Entity<Комнаты>(entity =>
        {
            entity.HasKey(e => e.IdКомнаты).HasName("PK__Комнаты__C49551A66B32F848");

            entity.ToTable("Комнаты");

            entity.Property(e => e.IdКомнаты).HasColumnName("ID_комнаты");
        });

        modelBuilder.Entity<Полки>(entity =>
        {
            entity.HasKey(e => e.IdПолки).HasName("PK__Полки__E55FCEAFCB22116D");

            entity.ToTable("Полки");

            entity.Property(e => e.IdПолки).HasColumnName("ID_полки");
            entity.Property(e => e.Fkряда).HasColumnName("FKряда");

            entity.HasOne(d => d.FkрядаNavigation).WithMany(p => p.Полкиs)
                .HasForeignKey(d => d.Fkряда)
                .HasConstraintName("FK__Полки__FKряда__70DDC3D8");
        });

        modelBuilder.Entity<ПопулярныеКниги>(entity =>
        {
            entity.HasKey(e => e.IdПопулярнойКниги).HasName("PK__Популярн__0898A491B71AC621");

            entity.ToTable("Популярные_книги");

            entity.Property(e => e.IdПопулярнойКниги).HasColumnName("ID_популярной_книги");
            entity.Property(e => e.Fkкниги).HasColumnName("FKкниги");

            entity.HasOne(d => d.FkкнигиNavigation).WithMany(p => p.ПопулярныеКнигиs)
                .HasForeignKey(d => d.Fkкниги)
                .HasConstraintName("FK__Популярны__FKкни__6754599E");
        });

        modelBuilder.Entity<Ряды>(entity =>
        {
            entity.HasKey(e => e.IdРяда).HasName("PK__Ряды__2F0999BABF17B5D5");

            entity.ToTable("Ряды");

            entity.Property(e => e.IdРяда).HasColumnName("ID_ряда");
            entity.Property(e => e.Fkсекции).HasColumnName("FKсекции");

            entity.HasOne(d => d.FkсекцииNavigation).WithMany(p => p.Рядыs)
                .HasForeignKey(d => d.Fkсекции)
                .HasConstraintName("FK__Ряды__FKсекции__71D1E811");
        });

        modelBuilder.Entity<Секции>(entity =>
        {
            entity.HasKey(e => e.IdСекции).HasName("PK__Секции__A60D6E501785FE77");

            entity.ToTable("Секции");

            entity.Property(e => e.IdСекции).HasColumnName("ID_секции");
            entity.Property(e => e.Fkкомнаты).HasColumnName("FKкомнаты");

            entity.HasOne(d => d.FkкомнатыNavigation).WithMany(p => p.Секцииs)
                .HasForeignKey(d => d.Fkкомнаты)
                .HasConstraintName("FK__Секции__FKкомнат__72C60C4A");
        });

        modelBuilder.Entity<СотрудникиБиблиотеки>(entity =>
        {
            entity.HasKey(e => e.IdСотрудника).HasName("PK__Сотрудни__E647AF7CB468013D");

            entity.ToTable("Сотрудники_библиотеки");

            entity.Property(e => e.IdСотрудника).HasColumnName("ID_сотрудника");
        });

        modelBuilder.Entity<СправочникОпераций>(entity =>
        {
            entity.HasKey(e => e.IdОперации).HasName("PK__Справочн__6CC393FC8F297CD7");

            entity.ToTable("Справочник_операций");

            entity.Property(e => e.IdОперации).HasColumnName("ID_операции");
        });

        modelBuilder.Entity<Формуляры>(entity =>
        {
            entity.HasKey(e => e.IdФормуляра).HasName("PK__Формуляр__2B51E722248F5B8E");

            entity.ToTable("Формуляры");

            entity.Property(e => e.IdФормуляра).HasColumnName("ID_формуляра");
            entity.Property(e => e.Fkоперации).HasColumnName("FKоперации");
            entity.Property(e => e.Fkсотрудника).HasColumnName("FKсотрудника");
            entity.Property(e => e.Fkчитателя).HasColumnName("FKчитателя");
            entity.Property(e => e.FkэкземпляраКниги).HasColumnName("FKэкземпляра_книги");
            entity.Property(e => e.ДатаОперации)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Дата_операции");
            entity.Property(e => e.СрокиПользования)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Сроки_пользования");

            entity.HasOne(d => d.FkоперацииNavigation).WithMany(p => p.Формулярыs)
                .HasForeignKey(d => d.Fkоперации)
                .HasConstraintName("FK__Формуляры__FKопе__59063A47");

            entity.HasOne(d => d.FkсотрудникаNavigation).WithMany(p => p.Формулярыs)
                .HasForeignKey(d => d.Fkсотрудника)
                .HasConstraintName("FK__Формуляры__FKсот__5812160E");

            entity.HasOne(d => d.FkчитателяNavigation).WithMany(p => p.Формулярыs)
                .HasForeignKey(d => d.Fkчитателя)
                .HasConstraintName("FK__Формуляры__FKчит__66603565");

            entity.HasOne(d => d.FkэкземпляраКнигиNavigation).WithMany(p => p.Формулярыs)
                .HasForeignKey(d => d.FkэкземпляраКниги)
                .HasConstraintName("FK__Формуляры__FKэкз__656C112C");
        });

        modelBuilder.Entity<Читатели>(entity =>
        {
            entity.HasKey(e => e.IdЧитателя).HasName("PK__Читатели__266C564A2ADD2002");

            entity.ToTable("Читатели");

            entity.Property(e => e.IdЧитателя).HasColumnName("ID_читателя");
            entity.Property(e => e.ЧитательскийБилет)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Читательский_билет");
        });

        modelBuilder.Entity<ЭкземплярыКниги>(entity =>
        {
            entity.HasKey(e => e.IdЭкземпляра).HasName("PK__Экземпля__623902C76F973EC0");

            entity.ToTable("Экземпляры_книги");

            entity.Property(e => e.IdЭкземпляра).HasColumnName("ID_экземпляра");
            entity.Property(e => e.Fkкниги).HasColumnName("FKкниги");
            entity.Property(e => e.Fkячейки).HasColumnName("FKячейки");

            entity.HasOne(d => d.FkкнигиNavigation).WithMany(p => p.ЭкземплярыКнигиs)
                .HasForeignKey(d => d.Fkкниги)
                .HasConstraintName("FK__Экземпляр__FKкни__68487DD7");

            entity.HasOne(d => d.FkячейкиNavigation).WithMany(p => p.ЭкземплярыКнигиs)
                .HasForeignKey(d => d.Fkячейки)
                .HasConstraintName("FK__Экземпляр__FKяче__693CA210");
        });

        modelBuilder.Entity<Ячейки>(entity =>
        {
            entity.HasKey(e => e.IdЯчейки).HasName("PK__Ячейки__3614A9EEBB3DFE83");

            entity.ToTable("Ячейки");

            entity.Property(e => e.IdЯчейки).HasColumnName("ID_ячейки");
            entity.Property(e => e.Fkячейки).HasColumnName("FKячейки");

            entity.HasOne(d => d.FkячейкиNavigation).WithMany(p => p.Ячейкиs)
                .HasForeignKey(d => d.Fkячейки)
                .HasConstraintName("FK__Ячейки__FKячейки__6FE99F9F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
