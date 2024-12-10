using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2FSemesterProjekt2024.Models
{
    public class Booking
    {
        public int BookingId { get; set; } // Primary Key

        public string? DriverId { get; set; } // Foreign Key to AspNetUsers for Driver
        public ApplicationUser? Driver { get; set; } // Navigation property for Driver

        public string? PassengerId { get; set; } // Foreign Key to AspNetUsers for Passenger
        public ApplicationUser? Passenger { get; set; } // Navigation property for Passenger

        public string PickupLocation { get; set; } = null!; // Required field
        public string DropoffLocation { get; set; } = null!; // Required field
        public int? Seats { get; set; } // Optional field
        public DateTime BookingTime { get; set; } // Required field
        public DateTime CreatedAt { get; set; } // Required field
        public DateTime? UpdatedAt { get; set; } // Optional field

        // New relationship: One Booking can have many BookingParticipants
        public ICollection<BookingParticipant> BookingParticipants { get; set; } = new List<BookingParticipant>();
    }
}

