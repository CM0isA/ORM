using Microsoft.EntityFrameworkCore;

namespace ORM2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Freelancer> freelancers { get; set; }
        public DbSet<Time> times { get; set; }
    }
}
