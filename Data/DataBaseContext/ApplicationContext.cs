using Microsoft.EntityFrameworkCore;
using Data.Models;
using Microsoft.Extensions.Configuration;

namespace Data.DataBaseContext
{
    public sealed class ApplicationContext: DbContext
    {
        //Создание базы данных
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;" +
                                     "Database=DriverLicense;Username=postgres;Password=1234");
        }
        
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersForms> UsersForms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<DriverLicenses> DriverLicenses { get; set; }
    }
}