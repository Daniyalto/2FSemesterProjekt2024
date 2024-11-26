using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using _2FSemesterProjekt2024.Services.EF;

[Authorize(Roles = "Passenger")]
public class PassengerProfileModel : PageModel
{
    private readonly IPassengerService _passengerService;

    public PassengerProfileModel(IPassengerService passengerService)
    {
        _passengerService = passengerService;
    }

    public Passenger Passenger { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
        if (userIdClaim == null)
        {
            return RedirectToPage("/Login");
        }

        var userId = int.Parse(userIdClaim.Value);
        Passenger = _passengerService.GetPassengerById(userId);

        return Passenger != null ? Page() : RedirectToPage("/Login");
    }
}
