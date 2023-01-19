using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BurgerAuth20106733.Data;
using BurgerAuth20106733.Models;

namespace BurgerAuth20106733.Pages.Burgers
{
    public class DeleteModel : PageModel
    {
        private readonly BurgerAuth20106733.Data.ApplicationDbContext _context;

        public DeleteModel(BurgerAuth20106733.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Burger Burger { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Burger == null)
            {
                return NotFound();
            }

            var burger = await _context.Burger.FirstOrDefaultAsync(m => m.burgerID == id);

            if (burger == null)
            {
                return NotFound();
            }
            else 
            {
                Burger = burger;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Burger == null)
            {
                return NotFound();
            }
            var burger = await _context.Burger.FindAsync(id);

            if (burger != null)
            {
                Burger = burger;
                _context.Burger.Remove(Burger);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
