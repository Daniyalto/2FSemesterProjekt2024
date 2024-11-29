using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.EF;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Passengers
{
    public class ProfileModel : PageModel

    {
        private readonly IPassengerService passengerService;

        [BindProperty]
        public Passenger Passenger { get; set; }


        public ProfileModel(IPassengerService service)
        {
            passengerService = service;
        }

        public IActionResult OnGet(int pid)
        {
            // Retrieve session values
            string userType = HttpContext.Session.GetString("UserType");
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userType == "Passenger" && userId.HasValue)
            {
                Passenger = passengerService.GetPassengerById(userId.Value);
                if (Passenger == null)
                {
                    return NotFound();
                }
                return Page();
            }

            // If no session, redirect to login
            return RedirectToPage("/Auth/Login");
        
            /*
            Passenger = passengerService.GetPassengerById(pid);

            if (Passenger == null)
            {

                return NotFound();
            }

            return Page();
            */
        }
    }
}
