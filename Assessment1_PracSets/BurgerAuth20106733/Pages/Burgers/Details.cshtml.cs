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
    public class DetailsModel : PageModel
    {
        private readonly BurgerAuth20106733.Data.ApplicationDbContext _context;

        public DetailsModel(BurgerAuth20106733.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
