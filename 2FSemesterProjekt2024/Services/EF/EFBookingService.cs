using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;

namespace _2FSemesterProjekt2024.Services.EF
{
    public class EFBookingService : IBookingService
    {

        private DriverDBContext _context;

        public EFBookingService(DriverDBContext context)
        {
            _context = context;
        }
    }
}
