using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BurgerAuth20106733.Data;
using BurgerAuth20106733.Models;

namespace BurgerAuth20106733.Pages.Purchases
{
    public class CreateModel : PageModel
    {
        private readonly BurgerAuth20106733.Data.ApplicationDbContext _context;

        public CreateModel(BurgerAuth20106733.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BurgerId"] = new SelectList(_context.Burger, "burgerID", "BurgerName");
            return Page();
        }

        [BindProperty]
        public Purchase Purchase { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Purchase.Add(Purchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
