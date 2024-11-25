using _2FSemesterProjekt2024.Models;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Services.Interfaces
{
    public interface IPassengerService
    {
        public IEnumerable<Passenger> GetPassengers();

        public Passenger GetPassengerById(int id);

      
        public void AddPassenger(Passenger passenger);

        public void DeletePassenger(Passenger passenger);

        public void UpdatePassenger(Passenger passenger);
    }
}
