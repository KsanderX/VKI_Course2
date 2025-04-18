using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Lab6.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public MyDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=./app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Master>().HasData(
                    new Master { Id = 1, Name = "Tom"},
                    new Master { Id = 2, Name = "Alice"},
                    new Master { Id = 3, Name = "Sam"}
            );

            modelBuilder.Entity<RequestStatus>().HasData(
                    new RequestStatus { Id = 1, Name = "New Request" },
                    new RequestStatus { Id = 2, Name = "In process" },
                    new RequestStatus { Id = 3, Name = "Completed" }
            );

            modelBuilder.Entity<CarType>().HasData(
                    new CarType { Id = 1, Name = "Sedan" },
                    new CarType { Id = 2, Name = "Coupe" },
                    new CarType { Id = 3, Name = "Universal" }
            );
        }


    }
}
