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
    public class IndexModel : PageModel
    {
        private readonly BurgerAuth20106733.Data.ApplicationDbContext _context;

        public IndexModel(BurgerAuth20106733.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Purchase> Purchase { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Purchase != null)
            {
                Purchase = await _context.Purchase
                .Include(p => p.TheBurger).ToListAsync();
            }
        }
    }
}
