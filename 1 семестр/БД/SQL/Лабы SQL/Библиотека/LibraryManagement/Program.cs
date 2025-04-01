using LibraryManagement.Models;
using System;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new LIbraryContext())
        {
            var seeder = new DataSeeder(context);

            seeder.SeedAuthors();
            seeder.SeedBooks();
            seeder.SeedGenres();
            seeder.SeedPublishers();
            seeder.SeedReaders();
            seeder.SeedEmployees();
            seeder.SeedOperations();

            Console.WriteLine("Заполнение справочников завершено.");
        }
    }
}