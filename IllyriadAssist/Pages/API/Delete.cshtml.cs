using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IllyriadAssist.Data;
using IllyriadAssist.Models;

namespace IllyriadAssist.Pages.API
{
    public class DeleteModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public DeleteModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public APISetting APISetting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            APISetting = await _context.APISettings.FirstOrDefaultAsync(m => m.APIid == id);

            if (APISetting == null)
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

            APISetting = await _context.APISettings.FindAsync(id);

            if (APISetting != null)
            {
                _context.APISettings.Remove(APISetting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
