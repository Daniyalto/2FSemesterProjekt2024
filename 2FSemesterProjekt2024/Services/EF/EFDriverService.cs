using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;

namespace _2FSemesterProjekt2024.Services.EF
{
    public class EFDriverService : IDriverService
    {

        private DriverDBContext _context;

        public EFDriverService(DriverDBContext context)
        {
            _context = context; 
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _context.Drivers;
        }
    }
}
