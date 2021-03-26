using Microsoft.EntityFrameworkCore;

namespace Persistence.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        {
           
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}
