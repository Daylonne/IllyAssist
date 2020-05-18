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
    public class DetailsModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public DetailsModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        public APISettings APISettings { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            APISettings = await _context.Settings.FirstOrDefaultAsync(m => m.APIid == id);

            if (APISettings == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
