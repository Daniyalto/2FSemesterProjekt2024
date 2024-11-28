using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Booking Booking { get; set; }
        private IBookingService bookingService;
        public CreateModel(IBookingService service)
        {
            bookingService = service;
        }
        public IActionResult OnPost(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bookingService.AddBooking(Booking);
            return RedirectToPage("GetDriver");
        }
    }   
}
