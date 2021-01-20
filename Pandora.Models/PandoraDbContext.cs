using Microsoft.EntityFrameworkCore;
using Pandora.Models.Entities;

namespace Pandora.Models
{
    public class PandoraDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<City> Cities { get; set; }

        public PandoraDbContext(DbContextOptions<PandoraDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(employee =>
            {
                employee.HasKey(o => o.Id);
                employee.HasOne(o => o.Department);
            });

            modelBuilder.Entity<Department>(department =>
            {
                department.HasKey(o => o.Id);
                department.HasOne(o => o.City);
            });

            modelBuilder.Entity<City>()
                .HasKey(o => new { o.Id });
        }
    }
}
