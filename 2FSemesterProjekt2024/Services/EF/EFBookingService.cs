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

        public IEnumerable<Booking> GetBookings()
        {
            return _context.Bookings;
        }

        public Booking GetBookingById(int bid)
        {
            return _context.Bookings.FirstOrDefault(x => x.BookingId == bid);
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void DeleteBooking(Booking booking)
        {
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }


        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

    }
}
}
