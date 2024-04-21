using Microsoft.EntityFrameworkCore;

namespace VanHorn_WebServices_Final.Models
{
    public class DomainContext : DbContext
    {
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
