using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataSeeder
{
    private readonly LIbraryContext _context;

    public DataSeeder(LIbraryContext context)
    {
        _context = context;
    }

    // Метод для заполнения таблицы "Авторы"
    public void SeedAuthors()
    {
        if (!_context.Авторыs.Any()) // Проверяем, пуста ли таблица
        {
            var authors = new[]
            {
                new Авторы { Имя = "Лев Толстой" },
                new Авторы { Имя = "Федор Достоевский " },
                // Добавьте других авторов
            };

            _context.Авторыs.AddRange(authors);
            _context.SaveChanges();
            Console.WriteLine("Таблица 'Авторы' заполнена.");
        }
        else
        {
            Console.WriteLine("Таблица 'Авторы' уже содержит данные.");
        }
    }

    // Метод для заполнения таблицы "Книги"
    public void SeedBooks()
    {
        if (!_context.Книгиs.Any())
        {
            var books = new[]
            {
                new Книги { /* Поля книги */ },
                new Книги { /* Поля книги */ },
                // Добавьте другие книги
            };

            _context.Книгиs.AddRange(books);
            _context.SaveChanges();
            Console.WriteLine("Таблица 'Книги' заполнена.");
        }
        else
        {
            Console.WriteLine("Таблица 'Книги' уже содержит данные.");
        }
    }

    // Метод для заполнения таблицы "Жанры"
    public void SeedGenres()
    {
        if (!_context.Жанрыs.Any())
        {
            var genres = new[]
            {
                new Жанры { /* Поля жанра */ },
                new Жанры { /* Поля жанра */ },
                // Добавьте другие жанры
            };

            _context.Жанрыs.AddRange(genres);
            _context.SaveChanges();
            Console.WriteLine("Таблица 'Жанры' заполнена.");
        }
        else
        {
            Console.WriteLine("Таблица 'Жанры' уже содержит данные.");
        }
    }

    // Метод для заполнения таблицы "Издательства"
    public void SeedPublishers()
    {
        if (!_context.Издательстваs.Any())
        {
            var publishers = new[]
            {
                new Издательства { /* Поля издательства */ },
                new Издательства { /* Поля издательства */ },
                // Добавьте другие издательства
            };

            _context.Издательстваs.AddRange(publishers);
            _context.SaveChanges();
            Console.WriteLine("Таблица 'Издательства' заполнена.");
        }
        else
        {
            Console.WriteLine("Таблица 'Издательства' уже содержит данные.");
        }
    }

    // Метод для заполнения таблицы "Читатели"
    public void SeedReaders()
    {
        if (!_context.Читателиs.Any())
        {
            var readers = new[]
            {
                new Читатели { /* Поля читателя */ },
                new Читатели { /* Поля читателя */ },
                // Добавьте других читателей
            };

            _context.Читателиs.AddRange(readers);
            _context.SaveChanges();
            Console.WriteLine("Таблица 'Читатели' заполнена.");
        }
        else
        {
            Console.WriteLine("Таблица 'Читатели' уже содержит данные.");
        }
    }

    // Метод для заполнения таблицы "Сотрудники библиотеки"
    public void SeedEmployees()
    {
        if (!_context.СотрудникиБиблиотекиs.Any())
        {
            var employees = new[]
            {
                new СотрудникиБиблиотеки { /* Поля сотрудника */ },
                new СотрудникиБиблиотеки { /* Поля сотрудника */ },
                // Добавьте других сотрудников
            };

            _context.СотрудникиБиблиотекиs.AddRange(employees);
            _context.SaveChanges();
            Console.WriteLine("Таблица 'Сотрудники библиотеки' заполнена.");
        }
        else
        {
            Console.WriteLine("Таблица 'Сотрудники библиотеки' уже содержит данные.");
        }
    }

    // Метод для заполнения таблицы "Справочник операций"
    public void SeedOperations()
    {
        if (!_context.СправочникОперацийs.Any())
        {
            var operations = new[]
            {
                new СправочникОпераций { /* Поля операции */ },
                new СправочникОпераций { /* Поля операции */ },
                // Добавьте другие операции
            };

            _context.СправочникОперацийs.AddRange(operations);
            _context.SaveChanges();
            Console.WriteLine("Таблица 'Справочник операций' заполнена.");
        }
        else
        {
            Console.WriteLine("Таблица 'Справочник операций' уже содержит данные.");
        }
    }
}