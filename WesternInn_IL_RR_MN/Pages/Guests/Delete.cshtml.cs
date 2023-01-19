﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WesternInn_IL_RR_MN.Data;
using WesternInn_IL_RR_MN.Models;

namespace WesternInn_IL_RR_MN.Pages.Guests
{
    public class DeleteModel : PageModel
    {
        private readonly WesternInn_IL_RR_MN.Data.ApplicationDbContext _context;

        public DeleteModel(WesternInn_IL_RR_MN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Guest Guest { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Guest == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest.FirstOrDefaultAsync(m => m.Email == id);

            if (guest == null)
            {
                return NotFound();
            }
            else 
            {
                Guest = guest;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Guest == null)
            {
                return NotFound();
            }
            var guest = await _context.Guest.FindAsync(id);

            if (guest != null)
            {
                Guest = guest;
                _context.Guest.Remove(Guest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
