using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2FSemesterProjekt2024.Pages.Passengers
{
    [Authorize(Roles = "passenger,passengerDriver")]
    public class GetPassengersModel : PageModel
    {
          public IEnumerable<Passenger> Passengers { get; set; }
          private IPassengerService passengerService;
          public GetPassengersModel(IPassengerService service)
          {
              passengerService = service;
          }
          public void OnGet()
          {
              Passengers = passengerService.GetPassengers();
          }
        
    }
}
