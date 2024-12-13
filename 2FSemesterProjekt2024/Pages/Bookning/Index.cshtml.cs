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
using System.Security.Claims;
using SQLitePCL;
using NuGet.Versioning;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _2FSemesterProjekt2024.Pages.Bookning
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly DriverDBContext _context;

        public IndexModel(DriverDBContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get; set; } = default!;

        public string UserId { get; set; }

        public async Task OnGetAsync()
        {
            UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (User.IsInRole("Driver"))
            {
                Booking = await _context.Bookings
                    .Include(b => b.Driver)
                    .Where(b => b.Driver.Id == UserId)
                    .ToListAsync();
            }
            else if (User.IsInRole("Passenger"))
            {
                Booking = await _context.Bookings
                    .Include(b => b.Passenger)
                    .Where(b => b.Passenger.Id == UserId)
                    .ToListAsync();
            }
            else if (User.IsInRole("PassengerDriver"))
            {
                Booking = await _context.Bookings
                .Include(b => b.Driver)
                .Include(b => b.Passenger)
                .Where(b => b.DriverId == UserId || b.PassengerId == UserId)
                .ToListAsync();
            }
        }
    }
}