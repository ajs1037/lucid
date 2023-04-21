using lucid.Models;
using Microsoft.EntityFrameworkCore;

namespace lucid.Data
{
    // A DbContext is a class that represents a database session and provides an API for accessing and manipulating data
    // stored in a database. In an ASP.NET Core application, you typically use a DbContext to interact with a relational database.

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
		// not needed
        public AppDbContext()
            : base()
        {
        }

        // Per ChatGPT: OnModelCreating is a method in Entity Framework Core that is called by the framework when it's building the model
        // for the database. The purpose of this method is to provide a way for developers to customize the model by configuring
        // entity mappings, relationships, constraints, and other database-specific settings.
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
