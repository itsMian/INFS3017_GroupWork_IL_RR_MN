using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerAuth20106733.Data;
using BurgerAuth20106733.Models;

namespace BurgerAuth20106733.Pages.Purchases
{
    public class EditModel : PageModel
    {
        private readonly BurgerAuth20106733.Data.ApplicationDbContext _context;

        public EditModel(BurgerAuth20106733.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Purchase Purchase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Purchase == null)
            {
                return NotFound();
            }

            var purchase =  await _context.Purchase.FirstOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }
            Purchase = purchase;
           ViewData["BurgerId"] = new SelectList(_context.Burger, "burgerID", "BurgerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(Purchase.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PurchaseExists(int id)
        {
          return _context.Purchase.Any(e => e.Id == id);
        }
    }
}
