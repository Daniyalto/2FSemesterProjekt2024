using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2FSemesterProjekt2024.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = "";

        [StringLength(200)]
        public string Address { get; set; } = "";

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [StringLength(200)]
        public string VehicleInfo { get; set; } = "";

        [StringLength(50)]
        public string LicenseNumber { get; set; } = "";

        [Range(0, 5)]
        public decimal? Rating { get; set; }

        public int? Points { get; set; }

        [StringLength(500)]
        public string? ProfilePictureUrl { get; set; }

        // Navigation Properties
        public virtual ICollection<Booking>? BookingsAsDriver { get; set; }
        public virtual ICollection<Booking>? BookingsAsPassenger { get; set; }
    }
}

