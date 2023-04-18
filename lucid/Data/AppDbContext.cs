using lucid.Models;
using Microsoft.EntityFrameworkCore;

namespace lucid.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey( k => new
            {
                k.Id
            });

            base.OnModelCreating( modelBuilder );
        }

        // define the table names for the models
        public DbSet<Customer> Customers { get; set; }
    }
}
