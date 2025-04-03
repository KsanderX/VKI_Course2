using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWebApp.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Комнаты> Комнаты { get; set; }
        public DbSet<Секции> Секции { get; set; }
        public DbSet<Ряды> Ряды { get; set; }
        public DbSet<Полки> Полки { get; set; }
        public DbSet<Ячейки> Ячейки { get; set; }
        public DbSet<Издательства> Издательства { get; set; }
        public DbSet<Жанры> Жанры { get; set; }
        public DbSet<Авторы> Авторы { get; set; }
        public DbSet<Авторы_книги> Авторы_книги { get; set; }
        public DbSet<Жанры_книги> Жанры_книги { get; set; }
        public DbSet<Издательства_книги> Издательства_книги { get; set; }
        public DbSet<Книги> Книги { get; set; }
        public DbSet<Читатели> Читатели { get; set; }
        public DbSet<Экземпляры_книги> Экземпляры_книги { get; set; }
        public DbSet<Формуляры> Формуляры { get; set; }
        public DbSet<Сотрудники_библиотеки> Сотрудники_библиотеки { get; set; }
        public DbSet<Справочник_операций> Справочник_операций { get; set; }
        public DbSet<Популярные_книги> Популярные_книги { get; set; }
    }
}