using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

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
            modelBuilder.Entity<Month>()
                .HasMany(e => e.Days)
                .WithOne(q => q.Month)
                .OnDelete(DeleteBehavior.Cascade);

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

            IList<Month> months = new List<Month>();

            modelBuilder.Entity<Month>().HasData(months);

            IList<Day> days = new List<Day>();
            days.Add(new Day() { DId = 1, DayName = "Sunday", Timeslots = [] } );
            days.Add(new Day() { DId = 2, DayName = "Monday", Timeslots = [] });
            days.Add(new Day() { DId = 3, DayName = "Tuesday", Timeslots = [] });
            days.Add(new Day() { DId = 4, DayName = "Wednesday", Timeslots = [] });
            days.Add(new Day() { DId = 5, DayName = "Thursday", Timeslots = [] });
            days.Add(new Day() { DId = 6, DayName = "Friday", Timeslots = [] });
            days.Add(new Day() { DId = 7, DayName = "Saturday", Timeslots = [] });

            modelBuilder.Entity<Month>().HasData(days);

            IList<Timeslot> timeslots = new List<Timeslot>();

            modelBuilder.Entity<Month>().HasData(timeslots);

            IList<ServiceProvider> serviceproviders = new List<ServiceProvider>();

            modelBuilder.Entity<Month>().HasData(serviceproviders);
        }
    }
}
