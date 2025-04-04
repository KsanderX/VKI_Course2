using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public class LiblaryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MyNewCroNbcg;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
                new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", DateOfIssue = new DateTime(2023, 10, 1), DateOfDelivery = new DateTime(2023, 10, 15), Genre = "Fiction", Description = "A classic novel by F. Scott Fitzgerald.", BookStatus = Status.Issued, UserId = 1 },
                new Book { Id = 2, Title = "Sapiens: A Brief History of Humankind", DateOfIssue = new DateTime(2023, 10, 2), DateOfDelivery = new DateTime(2023, 10, 16), Genre = "Non-Fiction", Description = "A thought-provoking book by Yuval Noah Harari.", BookStatus = Status.Instock, UserId = 1 },
                new Book { Id = 3, Title = "A Brief History of Time", DateOfIssue = new DateTime(2023, 10, 3), DateOfDelivery = new DateTime(2023, 10, 17), Genre = "Science", Description = "Stephen Hawking's groundbreaking book on cosmology.", BookStatus = Status.UnderMaintenance, UserId = 2 }
            );
        }
    }

}
