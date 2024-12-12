using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace _2FSemesterProjekt2024.Models
{
    public class BookingParticipant
    {
        [Key]
        public int ParticipantId { get; set; } // Primary Key

        public int BookingId { get; set; } // Foreign Key to Booking
        public Booking Booking { get; set; } = null!; // Navigation property for Booking

        public string UserId { get; set; } = null!; // Foreign Key to AspNetUsers
        public ApplicationUser User { get; set; } = null!; // Navigation property for User

        public string? RoleDescription { get; set; } // Optional Foreign Key to AspNetUsers
        public ApplicationUser? RoleDescriptionUser { get; set; } // Navigation property for RoleDescription
    }
}
