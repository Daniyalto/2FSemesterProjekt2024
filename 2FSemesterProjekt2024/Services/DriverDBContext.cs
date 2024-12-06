using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using _2FSemesterProjekt2024.Models;

namespace _2FSemesterProjekt2024.Services
{
    public class DriverDBContext : IdentityDbContext<ApplicationUser>
    {
        public DriverDBContext(DbContextOptions options)
            : base(options) {
        }

        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // Configure Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Passenger", NormalizedName = "PASSENGER" },
                new IdentityRole { Name = "Driver", NormalizedName = "DRIVER" },
                new IdentityRole { Name = "PassengerDriver", NormalizedName = "PASSENGERDRIVER" }
            );

            // Configure Relationships
            builder.Entity<Booking>()
                .HasOne(b => b.Driver)
                .WithMany(u => u.BookingsAsDriver)
                .HasForeignKey(b => b.DriverId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Driver

            builder.Entity<Booking>()
                .HasOne(b => b.Passenger)
                .WithMany(u => u.BookingsAsPassenger)
                .HasForeignKey(b => b.PassengerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Passenger
        }

    }
}