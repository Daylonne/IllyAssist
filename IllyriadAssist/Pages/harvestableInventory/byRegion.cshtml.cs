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

        public class NotifyJoinedData
        {
            public string NotifyRecordID { get; set; }
            public string CityName { get; set; }
            public string CityX { get; set; }
            public string CityY { get; set; }
            public string ItemX { get; set; }
            public string ItemY { get; set; }
            public string ItemCode { get; set; }
            public string QuantityOnGrid { get; set; }
            public string LastUpdated { get; set; }
            public string IllyriadRegionID { get; set; }
            public string RegionName { get; set; }

        }
        public class DistinctRegions
        {
            public string DistinctRegionID { get; set; }
            public string DistinctRegionName { get; set; }
        }
        public class RegionData
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        public IList<illyData> illyData { get;set; }
        public IList<DistinctRegions> DistinctRegion { get; set; }
        public IList<RegionData> RegionCoreData { get; set; }
        public IList<NotifyJoinedData> RecentNotifications { get; set; }
        public IList<RareMinerals> RareMineralItems { get; set; }
        public IList<RareHerbs> RareHerbItems { get; set; }

        public async Task OnGetAsync()
        {
            var DistinctRegionValues = (from dn in _context.IllyAPIData
                             join rn2 in _context.IllyRegions
                                on new { dn.IllyRegionID }
                                    equals new { rn2.IllyRegionID }
                                orderby rn2.RegionName descending
                             select new DistinctRegions
                                      {
                                        
                                        DistinctRegionID = rn2.IllyRegionID.ToString(),
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

            var maxNotifyDate = from c in _context.IllyAPIData
                                group c by new { c.CityName, c.ItemXGrid, c.ItemYGrid } into g
                                select new
                                {
                                    g.Key.CityName,
                                    g.Key.ItemXGrid,
                                    g.Key.ItemYGrid,
                                    NotifyDate = g.Max(a => a.NotificationDate)
                                };

            var masterQuery = (from con in _context.IllyAPIData
                                   //join min in _context.RareMinerals
                                   //on con.IllyriadCode
                                   //equals min.IllyCode
                                   //join her in _context.RareHerbs
                                   //on con.IllyriadCode
                                   //equals her.IllyCode
                                   //where con.ItemCategory == "HERBS"
                               join reg in _context.IllyRegions
                                  on con.IllyRegionID
                                      equals reg.IllyRegionID
                               join mx in maxNotifyDate
                                  on new { con.CityName, con.ItemXGrid, con.ItemYGrid }
                                      equals new { mx.CityName, mx.ItemXGrid, mx.ItemYGrid }
                               where con.NotificationDate == mx.NotifyDate
                               select new NotifyJoinedData
                               {
                                   NotifyRecordID = con.RecordID.ToString(),
                                   CityName = con.CityName,
                                   CityX = con.CityXGrid,
                                   CityY = con.CityYGrid,
                                   IllyriadRegionID = con.IllyRegionID.ToString(),
                                   //RegionName = reg.RegionName,
                                   //MineralResName = min.ItemName,
                                   //MineralResCode = min.IllyCode,
                                   //MineralResDes = min.ItemDescription,
                                   //MineralImgLoc = min.ImageName,
                                   //HerbResName = her.ItemName,
                                   //HerbResCode = her.IllyCode,
                                   //HerbResDes = her.ItemDescription,
                                   //HerbImgLoc = her.ImageName,
                                   ItemX = con.ItemXGrid,
                                   ItemY = con.ItemYGrid,
                                   ItemCode = con.IllyriadCode,
                                   QuantityOnGrid = con.GridQuantity,
                                   LastUpdated = con.NotificationDate,
                               }
                                );
            RecentNotifications = await masterQuery.ToListAsync();
            RareMineralItems = await _context.RareMinerals.ToListAsync();
            RareHerbItems = await _context.RareHerbs.ToListAsync();

        }
    }
}
