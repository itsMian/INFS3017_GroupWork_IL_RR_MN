using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BurgerAuth20106733.Data;
using BurgerAuth20106733.Models;

namespace BurgerAuth20106733.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly BurgerAuth20106733.Data.ApplicationDbContext _context;

        public DetailsModel(BurgerAuth20106733.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(m => m.EmailAddress == id);
            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
