using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IllyriadAssist.Data;
using IllyriadAssist.Models;

namespace IllyriadAssist.Pages.harvestableInventory
{
    public class EditModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public EditModel(IllyriadAssist.Data.IllyContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(illyData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!illyDataExists(illyData.RecordID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool illyDataExists(int id)
        {
            return _context.IllyAPIData.Any(e => e.RecordID == id);
        }
    }
}
