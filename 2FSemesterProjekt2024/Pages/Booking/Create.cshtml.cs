using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Booking
{
    public class CreateModel : PageModel
    {
        public class BookingPageModel : PageModel
        {
            private readonly UserManager<IdentityUser> _userManager;
            private readonly IBookingService _bookingService;

            [BindProperty]
            public BookingPageModel Booking { get; set; }

            public BookingPageModel(
                UserManager<IdentityUser> userManager,
                IBookingService bookingService)
            {
                _userManager = userManager;
                _bookingService = bookingService;
            }

            public async Task<IActionResult> OnGetAsync()
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToPage("/Account/Login");
                }

                // Get user roles
                var roles = await _userManager.GetRolesAsync(user);

                // Pre-fill the appropriate name based on role
                if (roles.Contains("Driver"))
                {
                    Booking = new BookingPageModel
                    {
                        DriverName = user.UserName,
                        PassengerName = null // Will be filled by actual passenger
                    };
                    ViewData["Role"] = "Driver";
                }
                else if (roles.Contains("Passenger"))
                {
                    Booking = new BookingPageModel
                    {
                        PassengerName = user.UserName,
                        DriverName = null // Will be filled by assigned driver
                    };
                    ViewData["Role"] = "Passenger";
                }

                return Page();
            }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                var user = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(user);

                // Ensure the correct name is set based on role
                if (roles.Contains("Driver"))
                {
                    Booking.DriverName = user.UserName;
                }
                else if (roles.Contains("Passenger"))
                {
                    Booking.PassengerName = user.UserName;
                }

                await _bookingService.CreateBookingAsync(Booking);
                return RedirectToPage("./BookingConfirmation");
            }
        }
        public void OnGet()
        {
        }
    }
}
