﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WesternInn_IL_RR_MN.Data;
using WesternInn_IL_RR_MN.Models;

namespace WesternInn_IL_RR_MN.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly WesternInn_IL_RR_MN.Data.ApplicationDbContext _context;

        public DeleteModel(WesternInn_IL_RR_MN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }
            var booking = await _context.Booking.FindAsync(id);

            if (booking != null)
            {
                Booking = booking;
                _context.Booking.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
