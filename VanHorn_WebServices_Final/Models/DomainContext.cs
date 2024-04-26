using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace VanHorn_WebServices_Final.Models
{
    // julian date might be usefull for resetting day objects once the day is in the past.
    public class DomainContext : DbContext
    {
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>()
                .HasMany(e => e.Timeslots)
                .WithOne(q => q.Day)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Timeslots)
                .WithOne(q => q.Customer)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServiceProvider>()
                .HasMany(e => e.Timeslots)
                .WithOne(q => q.ServiceProvider)
                .OnDelete(DeleteBehavior.Cascade);

            IList<Day> days = new List<Day>();
            days.Add(new Day() {Id = new DateTime(2024,4,27), Timeslots = [] });
            modelBuilder.Entity<Day>().HasData(days);

            IList<Customer> customers = new List<Customer>();
            customers.Add(new Customer() {CId = 1, FirstName = "Bob", LastName = "Dole", City = "Helena", State = "MT", Country = "United States", Email = "Bob.Dole@hotmail.com", Phone = "406-406-3333", Timeslots = [] });
            modelBuilder.Entity<Customer>().HasData(customers);

            IList<ServiceProvider> serviceproviders = new List<ServiceProvider>();
            serviceproviders.Add(new ServiceProvider() { SPId = 1, BusinessName = "ABC Plumbing", City = "Helena", State = "MT", Country = "United States", Phone = "406-111-2222", Timeslots = [] });
            modelBuilder.Entity<ServiceProvider>().HasData(serviceproviders);
        }
    }
}
