using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using IllyriadAssist.Data;
using IllyriadAssist.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using IllyriadAssist;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {

            Utilities xmlParser = new Utilities();
            xmlParser.XMLParser(_context);

        }
        public class RegExList
        {
            public string CityName { get; set; }
            public string CityGridX { get; set; }
            public string CityGridY { get; set; }
            public string ItemGridX { get; set; }
            public string ItemGridY { get; set; }
            public string RegionID { get; set; }
            public string ItemIllyCode { get; set; }
            public string ItemGridQty { get; set; }
            public string OccurrenceDate { get; set; }

        }

    }

}