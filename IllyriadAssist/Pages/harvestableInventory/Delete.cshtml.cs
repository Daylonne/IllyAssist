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
    public class DeleteModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public DeleteModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            illyData = await _context.IllyAPIData.FindAsync(id);

            if (illyData != null)
            {
                _context.IllyAPIData.Remove(illyData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
