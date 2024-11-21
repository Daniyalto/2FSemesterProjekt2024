using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Passengers
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Passenger Passenger { get; set; }

        IPassengerService passengerService;

        public DeleteModel(IPassengerService service)
        {
            this.passengerService = service;
            Passenger = new Passenger();
        }
        public void OnGet(int id)
        {
            Passenger = passengerService.GetPassengers(id);
        }
        public IActionResult OnPost()
        {
            passengerService.DeletePassenger(Passenger);

            return RedirectToPage("GetPassengers");
        }
    }
}
