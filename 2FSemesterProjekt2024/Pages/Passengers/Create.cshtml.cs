using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Passengers
{
    
    public class CreateModel : PageModel
    {
            [BindProperty]
            public Passenger Passenger { get; set; }
            private IPassengerService passengerService;
            public CreateModel(IPassengerService service)
            {
                passengerService = service;
            }
            public IActionResult OnPost(Passenger passenger)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                passengerService.AddPassenger(Passenger);
                return RedirectToPage("GetPassenger");
            }
    }
}
