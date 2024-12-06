using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services;
using Microsoft.AspNetCore.Authorization;

namespace _2FSemesterProjekt2024.Pages.Bookning
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly _2FSemesterProjekt2024.Services.DriverDBContext _context;

        public IndexModel(_2FSemesterProjekt2024.Services.DriverDBContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //if (User.Identity.Name == userName)
            //{
            //    Booking= await _context.Bookings.FindAsync(x => x.user == userName);
            //}


            var userEmail = User.Identity.Name;

            Booking = await _context.Bookings
                .Include(b => b.Driver)
                .Include(b => b.Passenger)
                .Where(b => b.Passenger.Email == userEmail)
                .Where(b => b.Driver.Email == userEmail).ToListAsync();

            //if (User.IsInRole("Driver"))
            //{
            //    Booking = await _context.Bookings
            //    .Include(b => b.Driver)
            //    .ToListAsync();
            //}
            //else if (User.IsInRole("Passenger"))
            //{
            //    Booking = await _context.Bookings
            //    .Include(b => b.Passenger)
            //    .ToListAsync();
            //}
            //else if (User.IsInRole("PassengerDriver"))
            //{
            //    Booking = await _context.Bookings
            //    .Include(b => b.Passenger).Include(b => b.Driver)
            //    .ToListAsync();
            //}

        }
    }
}
