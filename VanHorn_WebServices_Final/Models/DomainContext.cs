using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace VanHorn_WebServices_Final.Models
{
    // julian date might be usefull for resetting day objects once the day is in the past.
    public class DomainContext : DbContext
    {
        public DbSet<Credential> Credentials { get; set; }
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

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Credential)
                .WithOne(d => d.Customer)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServiceProvider>()
                .HasMany(e => e.Timeslots)
                .WithOne(q => q.ServiceProvider)
                .OnDelete(DeleteBehavior.Cascade);

            IList<Day> days = new List<Day>();
            DateTime date1 = new DateTime(2024, 04, 27);
            string datestring1 = date1.ToString("yyyy-MM-dd");
            days.Add(new Day() {Id = datestring1, Timeslots = [] });
            modelBuilder.Entity<Day>().HasData(days);

            Customer bobDole = new Customer() { CId = 1, FirstName = "Bob", LastName = "Dole", City = "Helena", State = "MT", Country = "United States", Email = "Bob.Dole@hotmail.com", Phone = "406-406-3333", Timeslots = [] };
            Credential doleCred = new Credential() { Id = 1, UserName = "bob", Password = "dole", CustomerId = 1 };
            bobDole.CredentialId = 1;

            IList<Customer> customers = new List<Customer>();
            customers.Add(bobDole);
            modelBuilder.Entity<Customer>().HasData(customers);

            IList<Credential> credentials = new List<Credential>();
            credentials.Add(doleCred);
            modelBuilder.Entity<Credential>().HasData(credentials);

            IList<ServiceProvider> serviceproviders = new List<ServiceProvider>();
            serviceproviders.Add(new ServiceProvider() { SPId = 1, BusinessName = "ABC Plumbing", City = "Helena", State = "MT", Country = "United States", Phone = "406-111-2222", Timeslots = [] });
            modelBuilder.Entity<ServiceProvider>().HasData(serviceproviders);
        }
    }
}
