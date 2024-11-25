using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Passengers
{
    public class UpdateModel : PageModel
    {
        private readonly IPassengerService passengerService;

        public UpdateModel(IPassengerService service)
        {
            passengerService = service;
        }

        [BindProperty]
        public Passenger Passenger { get; set; }

        public IActionResult OnGet(int pid)
        {
            if (Passenger != null)
            {
                return RedirectToPage("/Index");
            }
            Passenger = passengerService.GetPassengerById(pid);
            return Page();
        }

        public IActionResult OnPost(int pid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            passengerService.UpdatePassenger(Passenger);
            return RedirectToPage("GetPassenger");
        }
    }
}