using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Bookings
{
    public class GetBookingModel : PageModel
    {
        public IEnumerable<Booking> Bookings { get; set; }

        private IBookingService bookingService;
        public GetBookingModel(IBookingService service)
        {
            bookingService = service;
        }
        public void OnGet()
        {
            Bookings = bookingService.GetBookings();
        }
    }
}
