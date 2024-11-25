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
        
        public IEnumerable<Passenger> GetPassengers()
        {
            return _context.Passengers;
        }

        public Passenger GetPassengerById(int pid)
        {
            return _context.Passengers.FirstOrDefault(x => x.PassengerId == pid);
        }

        //public Passenger GetPassengerbyId(int id)
        //{

        //    return context.Passengers.Find(id);
        //}

        public void AddPassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
        }
        public void DeletePassenger(Passenger passenger)
        {
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                _context.SaveChanges();
            }
        }

        public void UpdatePassenger(Passenger passenger)
        {
            _context.Update(passenger);
            _context.SaveChanges();
        }
    }

}
