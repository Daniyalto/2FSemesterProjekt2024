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

        public IEnumerable<Passenger> Passengers { get; set; }

        public IActionResult OnGet(int id)
        {
            if (Passengers == null)
            {
                return RedirectToPage("./Index");
            }
            Passengers = passengerService.GetPassengerById(id);
            return Page();
        }

        public IActionResult OnPost()
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