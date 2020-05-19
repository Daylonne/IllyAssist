﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public IndexModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        public IList<RareMinerals> RareMinerals { get;set; }

        public async Task OnGetAsync()
        {
            RareMinerals = await _context.RareMinerals.ToListAsync();
        }
    }
}