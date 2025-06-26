using System.Windows.Media;
using Microsoft.EntityFrameworkCore;

namespace exam.Models
{
    class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Car> Car { get; set; }
        public AppDbContext()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DBSRV\\vip2024; Initial Catalog = Exam; Integrated Security = True; Encrypt = True; Trust Server Certificate = True");
            //optionsBuilder.UseSqlite("Data Source=exam.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
              new User { Id = 1, Login = "admin", Password = "admin", Surname = "Olegov", Name = "Oleg", Phone = "84276236", RoleId = 1 },
              new User { Id = 2, Name = "Petya", Login = "petya", Password = "1234", Surname = "Petrov", Phone = "81241782", RoleId = 2 }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin", AccessRights = "Admin" },
                new Role { Id = 2, RoleName = "User", AccessRights = "User" }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, VIN = "sk12po2", Name = "Volvo", Type = "Track", Description = "Описание", UserId = 2 }

            );
        }
    }
}
