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
        public virtual DbSet<BookingParticipant> BookingParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // Seed Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Passenger", NormalizedName = "PASSENGER" },
                new IdentityRole { Name = "Driver", NormalizedName = "DRIVER" },
                new IdentityRole { Name = "PassengerDriver", NormalizedName = "PASSENGERDRIVER" }
            );

            // Configure Booking Relationships
            builder.Entity<Booking>()
                .HasOne(b => b.Driver)
                .WithMany(u => u.BookingsAsDriver)
                .HasForeignKey(b => b.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Booking>()
                .HasOne(b => b.Passenger)
                .WithMany(u => u.BookingsAsPassenger)
                .HasForeignKey(b => b.PassengerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure BookingParticipant Relationships
            builder.Entity<BookingParticipant>()
                .HasOne(bp => bp.Booking)
                .WithMany(b => b.BookingParticipants)
                .HasForeignKey(bp => bp.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BookingParticipant>()
                .HasOne(bp => bp.User)
                .WithMany(u => u.BookingParticipants)
                .HasForeignKey(bp => bp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BookingParticipant>()
                .HasOne(bp => bp.RoleDescriptionUser)
                .WithMany(u => u.RoleDescriptions)
                .HasForeignKey(bp => bp.RoleDescription)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}