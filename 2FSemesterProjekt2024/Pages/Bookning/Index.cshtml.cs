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
        private readonly _2FSemesterProjekt2024.Services.DriverDBContext _context;

        public IndexModel(_2FSemesterProjekt2024.Services.DriverDBContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public string UserId { get; set; }



        public async Task OnGetAsync()
        {
            //if (User.Identity.Name == userName)
            //{
            //    Booking= await _context.Bookings.FindAsync(x => x.user == userName);
            //}


            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var userEmail = User.Identity.Name;

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToList();

            //Booking = await _context.Bookings
            //    .Include(b => b.Driver)
            //    .Include(b => b.Passenger)
            //    .Where(b => b.Passenger.Email == userEmail)
            //    .Where(b => b.Driver.Email == userEmail).ToListAsync();


            Booking = await _context.Bookings
                .Include(b => b.Passenger)
                .Include(b => b.Driver)
                .Where(b => b.Passenger.Id == UserId)
                .Where(b => b.Driver.Id == UserId).ToListAsync();

            
            //Booking = await _context.Bookings.Include(b => b.PassengerId).Include(b => b.DriverId).Where(b => b.PassengerId == userId).ToListAsync();



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
