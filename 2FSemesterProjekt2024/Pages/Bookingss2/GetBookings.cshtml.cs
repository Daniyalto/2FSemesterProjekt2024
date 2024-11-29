using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.EF;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Auth.Bookingss2
{
    public class GetBookingsModel : PageModel
    {
        public IEnumerable<Booking> Bookings { get; set; }

        private IBookingService bookingService;
        public GetBookingsModel(IBookingService service)
        {
            bookingService = service;
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
            Bookings = bookingService.GetBookings();
        }
    }
}
