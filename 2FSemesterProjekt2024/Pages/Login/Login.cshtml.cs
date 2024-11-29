using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IDriverService _driverService;
        private readonly IPassengerService _passengerService;

        public LoginModel(IDriverService driverService, IPassengerService passengerService)
        {
            _driverService = driverService;
            _passengerService = passengerService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            // Check if user is a driver
            var driver = _driverService.GetDrivers()
                .FirstOrDefault(d => d.Email == Email && d.Password == Password);

            if (driver != null)
            {
                HttpContext.Session.SetString("UserType", "Driver");
                HttpContext.Session.SetInt32("UserId", driver.DriverId);
                return RedirectToPage("/Profile/Profile");
            }

            var passenger = _passengerService.GetPassengers()
                .FirstOrDefault(p => p.Email == Email && p.Password == Password);
            if (passenger != null)
            {
                HttpContext.Session.SetString("UserType", "Passenger");
                HttpContext.Session.SetInt32("UserId", passenger.PassengerId);
                return RedirectToPage("/Profile/Profile");
            }

            // Invalid login
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return Page();
        }
    }
}
