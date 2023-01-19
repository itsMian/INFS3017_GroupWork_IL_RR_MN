using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Burger20106733.Data;
using Burger20106733.Models;

namespace Burger20106733.Pages.Burgers
{
    public class CreateModel : PageModel
    {
        private readonly Burger20106733.Data.Burger20106733Context _context;

        public CreateModel(Burger20106733.Data.Burger20106733Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Burger Burger { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Burger.Add(Burger);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
