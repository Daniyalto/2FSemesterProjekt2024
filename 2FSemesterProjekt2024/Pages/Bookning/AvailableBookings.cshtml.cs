using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace _2FSemesterProjekt2024.Pages.Bookning
{
    public class AvailableBookingsModel : PageModel
    {
        private readonly _2FSemesterProjekt2024.Services.DriverDBContext _context;

        public AvailableBookingsModel(_2FSemesterProjekt2024.Services.DriverDBContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public Claim UserRoles { get; set; }

        public async Task OnGetAsync()
        {
            UserRoles = User.FindFirst(ClaimTypes.Role);

            if (User.IsInRole("Driver"))
            {
                Booking = await _context.Bookings
                   //.Include(b => b.Driver)
                   .Include(b => b.Passenger).ToListAsync();
            }


            if (User.IsInRole("Passenger"))
            {
                Booking = await _context.Bookings
                   .Include(b => b.Driver.Id)
                   /*.Include(b => b.Passenger)*/.ToListAsync();
            }

        }
    }
}
