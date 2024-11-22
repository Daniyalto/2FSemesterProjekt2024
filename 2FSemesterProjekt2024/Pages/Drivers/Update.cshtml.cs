using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Drivers
{
    public class UpdateModel : PageModel
    {
        private readonly IDriverService driverService;

        public UpdateModel(IDriverService service)
        {
            driverService = service;
        }

        [BindProperty]
        public Driver Driver { get; set; }

        public IEnumerable<Driver> Drivers { get; set; }

        public IActionResult OnGet(int id)
        {
            if (Drivers == null)
            {
                return RedirectToPage("./Index");
            }
            Drivers = driverService.GetDriversById(id);
            return Page();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            driverService.UpdateDriver(Driver);
            return RedirectToPage("GetDrivers");
        }
    }
}
