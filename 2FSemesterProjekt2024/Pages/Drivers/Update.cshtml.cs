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

        public IActionResult OnGet(int id)
        {
            Driver = driverService.GetDrivers(id);
            if (Driver == null)
            {
                return RedirectToPage("./Index");
            }
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
