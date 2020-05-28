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
    public class byRegionModel : PageModel
    {
        private readonly IllyriadAssist.Data.IllyContext _context;

        public byRegionModel(IllyriadAssist.Data.IllyContext context)
        {
            _context = context;
        }

        public class DistinctRegions
        {
            public int DistinctRegionID { get; set; }
            public string DistinctRegionName { get; set; }
        }
        public class RareResourcesFound
        {
            public string ResourceName { get; set; }
            public string ResourceDescription { get; set; }
            public string ImageName { get; set; }
            public string ResourceCode { get; set; }

        }
        public class RegionData
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        public IList<illyData> illyData { get;set; }
        public IList<DistinctRegions> DistinctRegion { get; set; }
        public IList<RegionData> RegionCoreData { get; set; }
        public IList<illyData> RecentNotifies { get; set; }
        public IList<RareResourcesFound> RareResourcesCoreData { get; set; }

        public async Task OnGetAsync()
        {
            var DistinctRegionValues = (from dn in _context.IllyAPIData
                             join rn2 in _context.IllyRegions
                                on new { dn.IllyRegionID }
                                    equals new { rn2.IllyRegionID }
                                orderby rn2.RegionName descending
                             select new DistinctRegions
                                      {
                                        
                                        DistinctRegionID = rn2.IllyRegionID,
                                        DistinctRegionName = rn2.RegionName,

                                      }
                             ).Distinct().ToListAsync();

            DistinctRegion = await DistinctRegionValues;

            RegionCoreData = await _context.IllyRegions
                        .Select(r => new RegionData
                        {
                            Name = r.RegionName,
                            ID = r.IllyRegionID,

                        })
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

            var tempData = from c in _context.IllyAPIData
                           group c by new { c.IllyRegionID, c.ItemXGrid, c.ItemYGrid } into g
                           select new
                           {
                               g.Key.IllyRegionID,
                               g.Key.ItemXGrid,
                               g.Key.ItemYGrid,
                               NotifyDate = g.Max(a => a.NotificationDate)
                           };
            var joinQuery = (from c in _context.IllyAPIData
                             join s in tempData
                                on new { c.IllyRegionID, c.ItemXGrid, c.ItemYGrid }
                                    equals new { s.IllyRegionID, s.ItemXGrid, s.ItemYGrid }
                             where c.NotificationDate == s.NotifyDate
                             select c
                             ).ToListAsync();

            RecentNotifies = await joinQuery;
        }
    }
}
