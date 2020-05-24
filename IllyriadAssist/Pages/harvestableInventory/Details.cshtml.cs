using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IllyriadAssist.Data;
using IllyriadAssist.Models;

namespace IllyriadAssist.Pages.harvestableInventory
{
    public class DetailsModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public DetailsModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        public illyData illyData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            illyData = await _context.IllyAPIData.FirstOrDefaultAsync(m => m.RecordID == id);

            if (illyData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
