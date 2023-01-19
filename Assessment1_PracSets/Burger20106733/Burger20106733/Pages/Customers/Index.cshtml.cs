using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Burger20106733.Data;
using Burger20106733.Models;

namespace Burger20106733.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Burger20106733.Data.Burger20106733Context _context;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = string.Empty;

        public IndexModel(Burger20106733.Data.Burger20106733Context context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customer != null)
            {
                Customer = await _context.Customer.ToListAsync();
            }

            var customers = (IQueryable<Customer>)_context.Customer;

            if(!String.IsNullOrEmpty(SearchString))
            {
                customers = customers.Where(s => s.FamilyName.Contains(SearchString) || s.GivenName.Contains(SearchString));
            }
            if(customers != null)
            {
                Customer = await customers.ToListAsync();

            }
        }
    }
}
