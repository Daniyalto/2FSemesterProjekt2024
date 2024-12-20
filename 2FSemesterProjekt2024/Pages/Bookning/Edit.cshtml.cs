﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace _2FSemesterProjekt2024.Pages.Bookning
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly _2FSemesterProjekt2024.Services.DriverDBContext _context;

        public EditModel(_2FSemesterProjekt2024.Services.DriverDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public string UserId {  get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking =  await _context.Bookings.FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
           //ViewData["DriverId"] = new SelectList(_context.Users, "Id", "Id");
           //ViewData["PassengerId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.BookingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (User.IsInRole("Driver"))
            {
                Booking.DriverId = UserId;
            }
            if (User.IsInRole("Passenger"))
            {
                Booking.PassengerId = UserId;
            }


            _context.Bookings.Update(Booking);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");


        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
