using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IllyriadAssist.Data;
using IllyriadAssist.Models;

namespace IllyriadAssist.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public DetailsModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        public RareMinerals RareMinerals { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RareMinerals = await _context.RareMinerals.FirstOrDefaultAsync(m => m.ItemID == id);

            if (RareMinerals == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
