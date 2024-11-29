using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Bookings
{
    public class UpdateModel : PageModel
    {
        private readonly IBookingService bookingService;

        public UpdateModel(IBookingService service)
        {
            bookingService = service;
        }

        [BindProperty]
        public Booking Booking { get; set; }


        public IActionResult OnGet(int bid)
        {
            Booking = bookingService.GetBookingById(bid);
            if (Booking == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPost(int bid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var toBeUpdated = bookingService.GetBookingById(bid);
            if (toBeUpdated != null)
            {
                toBeUpdated.PickupLocation = Booking.PickupLocation;
                toBeUpdated.DropoffLocation = Booking.DropoffLocation;
                toBeUpdated.BookingTime = Booking.BookingTime;
                toBeUpdated.Seats = Booking.Seats;
                

                bookingService.UpdateBooking(toBeUpdated);
                return RedirectToPage("GetBooking");
            }
            return NotFound();
        }
    }
}
