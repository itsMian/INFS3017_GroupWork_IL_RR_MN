using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WesternInn_IL_RR_MN.Data;
using WesternInn_IL_RR_MN.Models;

namespace WesternInn_IL_RR_MN.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly WesternInn_IL_RR_MN.Data.ApplicationDbContext _context;

        public CreateModel(WesternInn_IL_RR_MN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GuestEmail"] = new SelectList(_context.Guest, "Email", "Email");
        ViewData["RoomID"] = new SelectList(_context.Room, "RoomID", "Level");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
