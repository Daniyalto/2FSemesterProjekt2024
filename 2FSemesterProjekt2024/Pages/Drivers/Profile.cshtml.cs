using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Drivers
{
    public class ProfileModel : PageModel

    {
        private readonly IDriverService _driverService;

        [BindProperty]
        public Driver Driver { get; set; }

        
        public ProfileModel(IDriverService service)
        {
            _driverService = service;
        }

        public IActionResult OnGet(int did)
        {
            
            Driver = _driverService.GetDriverById(did);

            if (Driver == null)
            {
                
                return NotFound();
            }

            return Page();
        }
    }
}
