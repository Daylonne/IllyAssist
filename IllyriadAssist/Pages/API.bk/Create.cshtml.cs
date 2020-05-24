using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IllyriadAssist.Data;
using IllyriadAssist.Models;

namespace IllyriadAssist.Pages.API
{
    public class CreateModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public CreateModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public APISettings APISettings { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.APISettings.Add(APISettings);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
