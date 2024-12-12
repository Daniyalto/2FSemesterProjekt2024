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

      [Table("Booking")]
        public partial class Booking
        {
            [Key]
            public int BookingId { get; set; }

            [ForeignKey("Driver")]
            public string? DriverId { get; set; }

            [ForeignKey("Passenger")]
            public string? PassengerId { get; set; }

            [ForeignKey("PassengerDriver")]
            public string? PassengerDriverId { get; set; }

            [Required]
            [StringLength(200)]
            public string PickupLocation { get; set; } = null!;

            [Required]
            [StringLength(200)]
            public string DropoffLocation { get; set; } = null!;

            [Range(1, int.MaxValue, ErrorMessage = "The number of seats must be at least 1.")]
            public int Seats { get; set; }

            [Column(TypeName = "datetime")]
            public DateTime BookingTime { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime? UpdatedAt { get; set; }

            // Navigation Properties
            public virtual ApplicationUser? Driver { get; set; }
            public virtual ApplicationUser? Passenger { get; set; }
        }
    }

