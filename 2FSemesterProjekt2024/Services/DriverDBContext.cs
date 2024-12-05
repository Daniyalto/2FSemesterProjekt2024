using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using _2FSemesterProjekt2024.Models;

namespace _2FSemesterProjekt2024.Services
{
    public class DriverDBContext : IdentityDbContext<ApplicationUser>
    {
        public DriverDBContext(DbContextOptions options)
            : base(options)
        {

        }


        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var passenger = new IdentityRole("Passenger");
            passenger.NormalizedName = "passenger";

            var driver = new IdentityRole("driver");
            driver.NormalizedName = "driver";

            var passengerDriver = new IdentityRole("PassengerDriver");
            passengerDriver.NormalizedName = "passengerDriver";

            builder.Entity<IdentityRole>().HasData(passenger,driver,passengerDriver);

        }
    }
}
