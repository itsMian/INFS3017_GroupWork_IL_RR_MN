using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BurgerAuth20106733.Data;
using BurgerAuth20106733.Models;

namespace BurgerAuth20106733.Pages.Purchases
{
    public class DeleteModel : PageModel
    {
        private readonly BurgerAuth20106733.Data.ApplicationDbContext _context;

        public DeleteModel(BurgerAuth20106733.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Purchase Purchase { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Purchase == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.FirstOrDefaultAsync(m => m.Id == id);

            if (purchase == null)
            {
                return NotFound();
            }
            else 
            {
                Purchase = purchase;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Purchase == null)
            {
                return NotFound();
            }
            var purchase = await _context.Purchase.FindAsync(id);

            if (purchase != null)
            {
                Purchase = purchase;
                _context.Purchase.Remove(Purchase);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
