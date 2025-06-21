using Microsoft.EntityFrameworkCore;

namespace exam.Models
{
    class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Request> Requests { get; set; }
        public AppDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=PC_SANYA;Initial Catalog=Exam;Integrated Security=True;Trust Server Certificate=True");
            optionsBuilder.UseSqlite("Data Source=exam.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
             new User {Id = 1, Name = "Oleg", Login = "admin", Password = "admin", RoleId = 1},
             new User {Id = 2, Name = "Petya", Login = "petya", Password = "1234", RoleId = 2}
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "User" }
            );
        }
    }
}
