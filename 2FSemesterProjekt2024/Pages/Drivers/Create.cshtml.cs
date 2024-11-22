using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Drivers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Driver Driver { get; set; }
        private IDriverService driverService;
        public CreateModel(IDriverService service)
        {
            driverService = service;
        }
        public IActionResult OnPost(Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            driverService.AddDriver(Driver);
            return RedirectToPage("GetDrivers");
        }
    }
}