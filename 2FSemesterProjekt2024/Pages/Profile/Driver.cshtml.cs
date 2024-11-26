using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Driver")]
public class DriverModel : PageModel
{
    private readonly IDriverService _driverService;

    public DriverModel(IDriverService driverService)
    {
        _driverService = driverService;
    }

    public Driver Driver { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
        if (userIdClaim == null)
        {
            return RedirectToPage("/Login");
        }

        var userId = int.Parse(userIdClaim.Value);
        Driver = _driverService.GetDriverById(userId);

        return Driver != null ? Page() : RedirectToPage("/Login");
    }
}

