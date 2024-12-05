using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2FSemesterProjekt2024.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";

        public DateTime CreatedAt { get; set; }


        public string VehicleInfo { get; set; } = "";


        public string LicenseNumber { get; set; } = "";


        public decimal? Rating { get; set; }

        public int? Points { get; set; }

       
        public string? ProfilePictureUrl { get; set; }

    }
}
