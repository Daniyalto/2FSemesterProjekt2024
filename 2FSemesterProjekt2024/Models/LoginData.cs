using System.ComponentModel.DataAnnotations;

namespace _2FSemesterProjekt2024.Models
{
    public class LoginData
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
