using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IllyriadAssist.Data;
using IllyriadAssist.Models;
using Microsoft.Extensions.Logging;
using IllyriadAssist;
using System;
using Microsoft.EntityFrameworkCore;

namespace IllyridAssist.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IllyContext _context;
        private readonly ILogger<IndexModel> _logger;
        public string Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IllyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public async Task OnPostParseXML()
        {

            Utilities xmlParser = new Utilities();
            xmlParser.XMLParser(_context);

        }
    }

}