using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

        public Driver GetDriverById(int did)
        {
            return _context.Drivers.FirstOrDefault(x => x.DriverId == did);
        }

        public void AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }

        public void DeleteDriver(Driver driver)
        {
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
            }
        }


        public void UpdateDriver(Driver driver)
        {
            _context.Drivers.Update(driver);
            _context.SaveChanges();
        }

    }
}
