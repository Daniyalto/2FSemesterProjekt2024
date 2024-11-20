using _2FSemesterProjekt2024.Models;

namespace _2FSemesterProjekt2024.Services.Interfaces
{
    public interface IDriverService
    {
        public IEnumerable<Driver> GetDrivers();

        public void AddDriver(Driver driver);

    }
}
