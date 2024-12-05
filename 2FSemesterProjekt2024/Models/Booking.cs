using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2FSemesterProjekt2024.Models
{

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int? DriverId { get; set; }

        public int? PassengerId { get; set; }

        [StringLength(200)]
        public string PickupLocation { get; set; } = null!;

        [StringLength(200)]
        public string DropoffLocation { get; set; } = null!;

        public int Seats { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime BookingTime { get; set; }

     
    }
}
