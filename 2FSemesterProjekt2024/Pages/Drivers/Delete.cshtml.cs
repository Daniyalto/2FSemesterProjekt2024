using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Drivers
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Driver Driver { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }

        IDriverService driverService;

        public DeleteModel(IDriverService service)
        {
            this.driverService = service;
            Driver = new Driver();
        }
        public void OnGet(int id)
        {
            Drivers = driverService.GetDriversById(id);
        }
        public IActionResult OnPost()
        {
            driverService.DeleteDriver(Driver);

            return RedirectToPage("GetDriver");
        }
    }
}
