using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _2FSemesterProjekt2024.Services.Interfaces;
using _2FSemesterProjekt2024.Models;
using Microsoft.AspNetCore.Authorization;

namespace _2FSemesterProjekt2024.Pages.Drivers
{
    [Authorize(Roles = "driver,passengerDriver")]
    public class GetDriverModel : PageModel
    {
        public IEnumerable<Driver> Drivers { get; set; }
        private IDriverService driverService;
        public GetDriverModel(IDriverService service)
        {
            driverService = service;
        }
        public void OnGet()
        {
            Drivers = driverService.GetDrivers();
        }
    }
}
