using Burger20106733.Data;
using Burger20106733.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Burger20106733.Pages.Burgers
{
    public class OrderModel : PageModel
    {
        private readonly Burger20106733.Data.Burger20106733Context _context;

        public OrderModel(Burger20106733.Data.Burger20106733Context context)
        {
            _context = context;
        }
        public SelectList BurgerList { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public BurgerOrder BurgerOrder { get; set; } = default!;

        public IActionResult OnGet()
        {
            BurgerList = new SelectList(_context.Burger, "BurgerName", "BurgerName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            BurgerList = new SelectList(_context.Burger, "BurgerName", "BurgerName");

            if(!ModelState.IsValid  || BurgerOrder == null)
            {
                return Page();
            }

            var burger = await _context.Burger.FirstOrDefaultAsync(b => b.BurgerName == BurgerOrder.BurgerName);
            if(burger != null)
            {
                ViewData["TotalPrice"] = burger.Price * BurgerOrder.BurgerCount;
            }
            return Page();
        }
    }
}
