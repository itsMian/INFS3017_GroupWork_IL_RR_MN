using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Burger20106733.Data;
using Burger20106733.Models;

namespace Burger20106733.Pages.Burgers
{
    public class IndexModel : PageModel
    {
        private readonly Burger20106733.Data.Burger20106733Context _context;

        public IndexModel(Burger20106733.Data.Burger20106733Context context)
        {
            _context = context;
        }

        public IList<Burger> Burger { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Burger != null)
            {
                Burger = await _context.Burger.ToListAsync();
            }
        }
    }
}
