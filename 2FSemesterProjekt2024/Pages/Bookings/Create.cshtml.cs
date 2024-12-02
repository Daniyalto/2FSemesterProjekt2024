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

        [BindProperty]
        public int PassengerId { get; set; }

        private IBookingService bookingService;
        public CreateModel(IBookingService service)
        {
            bookingService = service;
        }

        public void OnGet(int pid)
        {
            // Store the PassengerId when the page loads
            PassengerId = pid;
        }

       
        public IActionResult OnPost(Booking booking)
        {
            var newBooking = new Booking
            {
                PassengerId = this.PassengerId
            };
            



            if (!ModelState.IsValid)
            {
                return Page();
            }
            bookingService.AddBooking(Booking);
            return RedirectToPage("GetBooking");
        }
    }   
}
