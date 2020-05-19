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
    public class IndexModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public IndexModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        public IList<APISettings> APISettings { get;set; }

        public async Task OnGetAsync()
        {
            APISettings = await _context.APISettings.ToListAsync();
        }
    }
}
