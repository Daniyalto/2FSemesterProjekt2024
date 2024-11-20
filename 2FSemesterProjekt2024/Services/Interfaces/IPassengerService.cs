using _2FSemesterProjekt2024.Models;

namespace _2FSemesterProjekt2024.Services.Interfaces
{
    public interface IPassengerService
    {
        public IEnumerable<Passenger> GetPassengers();

        public IEnumerable<Passenger> GetPassengerById(int id);

    }
}
