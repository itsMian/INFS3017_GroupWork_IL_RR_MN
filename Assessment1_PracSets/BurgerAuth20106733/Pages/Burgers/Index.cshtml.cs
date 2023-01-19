﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly BurgerAuth20106733.Data.ApplicationDbContext _context;

        public IndexModel(BurgerAuth20106733.Data.ApplicationDbContext context)
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
