using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.EF;
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


        public IActionResult OnGet(int did)
        {
           Driver = driverService.GetDriverById(did);
            if (Driver == null)
            {
                return RedirectToPage("/Index");
            }
           
            return Page();
        }

        public IActionResult OnPost(int did)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var toBeUpdated = driverService.GetDriverById(did);
            if (toBeUpdated != null)
            {
                toBeUpdated.DriverName = Driver.DriverName;
                toBeUpdated.Email = Driver.Email;
                toBeUpdated.PhoneNumber = Driver.PhoneNumber;
                toBeUpdated.Password = Driver.Password;
                toBeUpdated.VehicleInfo = Driver.VehicleInfo;
                toBeUpdated.LicenseNumber = Driver.LicenseNumber;

                driverService.UpdateDriver(toBeUpdated);
                return RedirectToPage("GetDriver");
            }
            return NotFound();
        }
    }
}
