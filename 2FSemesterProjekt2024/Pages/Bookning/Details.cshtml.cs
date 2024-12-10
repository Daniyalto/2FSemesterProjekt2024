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
    public class DetailsModel : PageModel
    {
        private readonly _2FSemesterProjekt2024.Services.DriverDBContext _context;

        public DetailsModel(_2FSemesterProjekt2024.Services.DriverDBContext context)
        {
            _context = context;
        }

        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
