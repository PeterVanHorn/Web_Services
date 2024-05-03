//Peter Van Horn
//Web Services Final
//05/03/2024
//Context Class

using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace VanHorn_WebServices_Final.Models
{
    public class DomainContext : DbContext
    {
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Business> Businesses { get; set; }
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

            modelBuilder.Entity<Business>()
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

            Customer steveFrench = new Customer() { CId = 2, FirstName = "Steve", LastName = "French", City = "Butte", State = "MT", Country = "United States", Email = "Steven@example.com", Phone = "444-333-2222", Timeslots = [] };
            Credential frenchCred = new Credential() { Id = 2, UserName = "steve", Password = "french", CustomerId = 2 };
            steveFrench.CredentialId = 2;

            IList<Customer> customers = [bobDole, steveFrench];
            modelBuilder.Entity<Customer>().HasData(customers);

            Business plumber = new Business() { SPId = 1, BusinessName = "ABC Plumbing", City = "Helena", State = "MT", Country = "United States", Phone = "406-111-2222", Timeslots = [] };
            Credential plumbCred = new Credential() { Id = 3, UserName = "plumb", Password = "password", BusinessId = 1};
            plumber.CredentialId = 3;

            IList<Credential> credentials = [doleCred, frenchCred, plumbCred];
            modelBuilder.Entity<Credential>().HasData(credentials);

            IList<Business> businesses = new List<Business>();
            businesses.Add(plumber);
            modelBuilder.Entity<Business>().HasData(businesses);
        }
    }
}
