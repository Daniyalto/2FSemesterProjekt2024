using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Auth
{
    public class ProfileModel : PageModel
    {
        private readonly IDriverService _driverService;
        private readonly IPassengerService _passengerService;

        public ProfileModel(IDriverService driverService, IPassengerService passengerService)
        {
            _driverService = driverService;
            _passengerService = passengerService;
        }

        public string UserType { get; private set; }
        public Driver Driver { get; private set; }
        public Passenger Passenger { get; private set; }

        public IActionResult OnGet()
        {
            UserType = HttpContext.Session.GetString("UserType");
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (string.IsNullOrEmpty(UserType) || !userId.HasValue)
            {
                return RedirectToPage("/Auth/Login");
            }

            if (UserType == "Driver")
            {
                Driver = _driverService.GetDriverById(userId.Value);
            }
            else if (UserType == "Passenger")
            {
                Passenger = _passengerService.GetPassengerById(userId.Value);
            }

            if (Driver == null && Passenger == null)
            {
                return NotFound(); // If no user is found, return a 404
            }

            return Page();
        }
    }
}
