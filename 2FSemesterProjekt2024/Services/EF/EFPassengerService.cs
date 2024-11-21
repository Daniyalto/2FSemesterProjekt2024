using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;

namespace _2FSemesterProjekt2024.Services.EF
{
    public class EFPassengerService : IPassengerService
    {

        private DriverDBContext _context;

        public EFPassengerService(DriverDBContext context)
        {
            _context = context;
        }

        public void AddPassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
        }
    }

}
