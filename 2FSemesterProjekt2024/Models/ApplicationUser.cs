using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2FSemesterProjekt2024.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string? VehicleInfo { get; set; }
        public string? LicenseNumber { get; set; }

        public decimal? Rating { get; set; }
        public int? Points { get; set; }

        // Navigation Properties
        public ICollection<BookingParticipant> BookingParticipants { get; set; } = new List<BookingParticipant>();
        public ICollection<BookingParticipant> RoleDescriptions { get; set; } = new List<BookingParticipant>();
        public ICollection<Booking> BookingsAsDriver { get; set; } = new List<Booking>();
        public ICollection<Booking> BookingsAsPassenger { get; set; } = new List<Booking>();
    }
}

