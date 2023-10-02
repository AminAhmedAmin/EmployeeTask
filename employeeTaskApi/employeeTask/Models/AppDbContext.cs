using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace employeeTask.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model validations here, e.g., applying DTO validations.
            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.Name)
            //    .IsRequired()
            //    .HasAnnotation("RegularExpression", new RegularExpressionAttribute(@"^\S+$"));

            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.Age)
            //    .IsRequired()
            //    .HasAnnotation("Range", new RangeAttribute(21, int.MaxValue));

           

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading
        }
    }
}
