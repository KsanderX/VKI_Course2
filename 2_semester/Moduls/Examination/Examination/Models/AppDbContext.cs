using Microsoft.EntityFrameworkCore;

namespace Examination.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public AppDbContext()
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DBSRV\\vip2024;Initial Catalog=Examination;Integrated Security=True;Trust Server Certificate=True");
            optionsBuilder.UseSqlite("Data Source= /examination.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
             new User { Id = 1, Login = "admin", Password = "admin", Surname = "Olegov", Name = "Oleg", Phone = "84276236", RoleId = 1 },
             new User { Id = 2, Name = "Petya", Login = "petya", Password = "1234", Surname = "Petrov", Phone = "81241782", RoleId = 2 }
            );

            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = 1, Name = "Admin", AccessRights = "Admin" },
                new Roles { Id = 2, Name = "User", AccessRights = "User" }
            );
        }
    }
}
