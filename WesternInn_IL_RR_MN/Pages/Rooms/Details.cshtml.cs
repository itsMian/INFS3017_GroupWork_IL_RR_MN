using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WesternInn_IL_RR_MN.Data;
using WesternInn_IL_RR_MN.Models;

namespace WesternInn_IL_RR_MN.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly WesternInn_IL_RR_MN.Data.ApplicationDbContext _context;

        public DetailsModel(WesternInn_IL_RR_MN.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FirstOrDefaultAsync(m => m.RoomID == id);
            if (room == null)
            {
                return NotFound();
            }
            else 
            {
                Room = room;
            }
            return Page();
        }
    }
}
