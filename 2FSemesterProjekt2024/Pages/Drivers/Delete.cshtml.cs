using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.EF;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace _2FSemesterProjekt2024.Pages.Drivers
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Driver Driver { get; set; }
       
        IDriverService driverService;

        public DeleteModel(IDriverService service)
        {
            this.driverService = service;
            Driver = new Driver();
        }
        public void OnGet(int did)
        {
            Driver = driverService.GetDriverById(did);
        }
        public IActionResult OnPost(int did)
        {
           Driver toBeDeleted = driverService.GetDriverById(did);
            if (toBeDeleted != null)
            {
                driverService.DeleteDriver(toBeDeleted);
            }

            return RedirectToPage("GetDriver");
        }
    }
}
