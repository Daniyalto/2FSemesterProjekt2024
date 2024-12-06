using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024.Pages.Bookning
{
    public class CreateModel : PageModel
    {
        private readonly _2FSemesterProjekt2024.Services.DriverDBContext _context;

        public CreateModel(_2FSemesterProjekt2024.Services.DriverDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int uid)
        {
        //ViewData["DriverId"] = new SelectList(_context.Users, "Id", "Id");
        //ViewData["PassengerId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userName = User.Identity?.Name;
            if (userName == null)
            {
                ModelState.AddModelError("", "User is not logged in.");
                return Page();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName || u.Email == userName);
            if (user == null)
            {
                ModelState.AddModelError("", "Logged-in user not found.");
                return Page();
            }

            Booking.DriverId = user.Id;

            Booking.CreatedAt = DateTime.UtcNow;
            Booking.UpdatedAt = DateTime.UtcNow;

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
