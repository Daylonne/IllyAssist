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
    
    public class IndexModel : PageModel
    {


        private readonly IllyriadAssist.Data.IllyContext _context;

        public class RareResourcesFound
        {
           public string ResourceName { get; set; }
           public string ResourceDescription { get; set; }
           public string ImageName { get; set; }
           public string ResourceCode { get; set; }

        }

        public class ByCityView
        {
            public string DistinctCityName { get; set; }
            public string DistinctCityX { get; set; }
            public string DistinctCityY { get; set; }
        }

        public IndexModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        public IList<illyData> illyData { get;set; }
        public IList<ByCityView> Cities { get; set; }
        public IList<RareResourcesFound> RareResourcesCoreData { get; set; }
        public IList<illyData> RecentNotifies { get; set; }


        public async Task OnGetAsync()
        {
            var tempData = from c in _context.IllyAPIData
                           group c by new { c.CityName, c.ItemXGrid, c.ItemYGrid } into g
                           select new
                           {
                               g.Key.CityName,
                               g.Key.ItemXGrid,
                               g.Key.ItemYGrid,
                               NotifyDate = g.Max(a => a.NotificationDate)
                           };
            var joinQuery = (from c in _context.IllyAPIData
                                  join s in tempData
                                     on new { c.CityName, c.ItemXGrid, c.ItemYGrid }
                                         equals new { s.CityName, s.ItemXGrid, s.ItemYGrid }
                                  where c.NotificationDate == s.NotifyDate
                                  select c).ToListAsync();

            RecentNotifies = await joinQuery;


            Cities = await _context.IllyAPIData
                        .Select(c => new ByCityView
                        {
                            DistinctCityName = c.CityName,
                            DistinctCityX = c.CityXGrid,
                            DistinctCityY = c.CityYGrid,
                        })
                        .Distinct()
                        .ToListAsync();

            RareResourcesCoreData = await _context.RareMinerals
                        .Select(rareMins => new RareResourcesFound
                        {
                            ResourceName = rareMins.ItemName,
                            ResourceDescription = rareMins.ItemDescription,
                            ResourceCode = rareMins.IllyCode,
                            ImageName = rareMins.ImageName,

                        })
                        .ToListAsync();
        }
    }
}
