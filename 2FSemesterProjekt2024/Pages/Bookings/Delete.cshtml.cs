using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Booking Booking { get; set; }

        IBookingService _bookingService;

        public DeleteModel(IBookingService service)
        {
            this._bookingService = service;
            //Booking = new Booking();
        }
        public void OnGet(int bid)
        {
            Booking = _bookingService.GetBookingById(bid);
        }
        public IActionResult OnPost(int bid)
        {
            Booking toBeDeleted = _bookingService.GetBookingById(bid);
            if (toBeDeleted != null)
            {
                _bookingService.DeleteBooking(toBeDeleted);
            }

            return RedirectToPage("GetBooking");
        }
    }
}
