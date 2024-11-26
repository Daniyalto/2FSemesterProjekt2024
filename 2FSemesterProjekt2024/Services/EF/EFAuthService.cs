using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;

namespace _2FSemesterProjekt2024.Services.EF
{
    public class EFAuthService : IAuthService
    {
        private readonly DriverDBContext _context;

        public EFAuthService(DriverDBContext context)
        {
            _context = context;
        }

        public bool ValidateCredentials(string email, string password, out string userType, out int userId) {
            var driver = _context.Drivers.FirstOrDefault(d => d.Email == email && d.Password == password);
            if (driver != null)
            {
                userType = "Driver";
                userId = driver.DriverId;
                return true;
            }

            var passenger = _context.Passengers.FirstOrDefault(p => p.Email == email && p.Password == password);
            if (passenger != null)
            {
                userType = "Passenger";
                userId = passenger.PassengerId;
                return true;
            }

            userType = string.Empty;
            userId = 0;
            return false;
        }
    }

}
