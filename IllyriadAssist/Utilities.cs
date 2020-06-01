using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using IllyriadAssist.Data;
using IllyriadAssist.Models;
using SQLitePCL;

namespace IllyriadAssist
{
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

    public class Utilities
    {
        //Function to Disassemble Harvester Notifications
        public static RegExList DisassembleHarvestNotify(string notifyText)
        {
            //Illy Miner Harvester Codes
            string humanMiner = "[@i=5|678]";
            string elvenMiner = "[@i=5|682]";
            string dwarvenMiner = "[@i=5|686]";
            string orcMiner = "[@i=5|690]";

            //Illy Herbalist Harvester Codes
            string humanHerbalist = "[@i=5|677]";
            string elvenHerbalist = "[@i=5|681]";
            string dwarvenHerbalist = "[@i=5|685]";
            string orcHerbalist = "[@i=5|689]";

            //REGEX Strings for Notifications
            Regex rgxHarvesterType = new Regex(@"\[@i=.{1,6}");
            Regex rgxCityName = new Regex(@"(?<=\[@t=)(.*?)(?=\|)");
            Regex rgxGridsAndRegionID = new Regex(@"(?<=\|)(\d{1,3}?)(?=\|)|(?<=\=)(\d{3}?)(?=\|)");
            Regex rgxItemIllyCode = new Regex(@"\[@c=.{1,4}");
            Regex rgxCheckIfHarvested = new Regex(@"but did not find any items requring their specialist skills");
            Regex rgxItemQtyOnGrid = new Regex(@"(\.\s)(\d*)(\s)");

            //Check to make sure only Miner units (need to populate Rare Herbs)
            MatchCollection harvesterCodeMatches = rgxHarvesterType.Matches(notifyText);
            string harvesterIllyCode = harvesterCodeMatches[0].Value;

            // Create a List Object to store RegExResults
            var regExResults = new RegExList();

            //If Unit Code is of a Miner - Continue
            if (harvesterIllyCode.Contains(humanMiner) || harvesterIllyCode.Contains(elvenMiner) ||
                harvesterIllyCode.Contains(dwarvenMiner) || harvesterIllyCode.Contains(orcMiner) ||
                harvesterIllyCode.Contains(humanHerbalist) || harvesterIllyCode.Contains(elvenHerbalist) ||
                harvesterIllyCode.Contains(dwarvenHerbalist) || harvesterIllyCode.Contains(orcHerbalist))
            {
                //Assemble RegEx Match Collections
                MatchCollection cityMatches = rgxCityName.Matches(notifyText);
                MatchCollection gridAndRegionMatches = rgxGridsAndRegionID.Matches(notifyText);
                MatchCollection itemIllyCodeMatches = rgxItemIllyCode.Matches(notifyText);
                MatchCollection itemQtyOnGridMatches = rgxItemQtyOnGrid.Matches(notifyText);

                //Link Individual Matches
                regExResults.CityName = cityMatches[0].Value;
                regExResults.CityGridX = gridAndRegionMatches[0].Value;
                regExResults.CityGridY = gridAndRegionMatches[1].Value;
                regExResults.ItemGridX = gridAndRegionMatches[7].Value;
                regExResults.ItemGridY = gridAndRegionMatches[8].Value;
                regExResults.RegionID = gridAndRegionMatches[9].Value;
                regExResults.ItemIllyCode = itemIllyCodeMatches[0].Value;

                // Check if there is anything left on Grid
                if (itemQtyOnGridMatches.Count > 0)
                {
                    regExResults.ItemGridQty = itemQtyOnGridMatches[0].Value.Substring(2).Trim(); // Quantity on Grid [7]
                }
                else
                {

                    regExResults.ItemGridQty = "0"; // Quantity on Grid [7]
                        
                }

            }

            return regExResults;

        }

        //Function to Parse Illyriad's XML
        public void XMLParser(IllyContext context)
        {

            var apiKey = context.APISettings
                         .Where(w => w.APIid == 1)
                         .Select(w => w.APIKey)
                         .Single();

            String illyriadLink = "https://elgea.illyriad.co.uk/external/notificationsapi/";
            String notifyURLapi = illyriadLink + apiKey;
            var client = new WebClient();
            var xml = client.DownloadString(notifyURLapi);
            var xmlDoc = XDocument.Parse(xml);
            IEnumerable<XElement> XElementList =
                from el in xmlDoc.Root.Elements()
                select el;

            foreach (XElement xElement in XElementList)
            {
                if (xElement.Name == "notifications")
                {
                    var notificationsList = xElement.Elements();

                    foreach (XElement xNotify in notificationsList)
                    {
                        string notificationID = xNotify.Element("notification").Attribute("id").Value;
                        Console.WriteLine("Processing Notification ID: " + notificationID);

                        if (xNotify.Element("notificationtype").Attribute("id").Value == "45")
                        {

                            string notificationTypeID = xNotify.Element("notificationtype").Attribute("id").Value;
                            string notificationCategoryID = xNotify.Element("notificationoveralltype").Attribute("id").Value;
                            string notificationCategory = xNotify.Element("notificationoveralltype").Value;
                            string notificationDetail = xNotify.Element("notificationdetail").Value;
                            string notificationOccurrence = xNotify.Element("notificationoccurrencedate").Value;

                            //Illy Miner Harvester Codes
                            string humanMiner = "[@i=5|678]";
                            string elvenMiner = "[@i=5|682]";
                            string dwarvenMiner = "[@i=5|686]";
                            string orcMiner = "[@i=5|690]";

                            //Illy Herbalist Harvester Codes
                            string humanHerbalist = "[@i=5|677]";
                            string elvenHerbalist = "[@i=5|681]";
                            string dwarvenHerbalist = "[@i=5|685]";
                            string orcHerbalist = "[@i=5|689]";

                            string itemCategory = "";

                            //New Exacting RegEx
                            Regex rgxItemXyAndRegionID = new Regex(@"(?!\[\@l\=)(\d{1,3}|-\d{1,3})(?:\|)(\d{1,3}|-\d{1,3})(?:\|)(\d{1,3}|-\d{1,3})(?:\|)(\d{1,3}|-\d{1,3})(?:\|)(\d{1,3}|-\d{1,3})(?=\])");
                            Regex rgxCityNameAndXyGrid = new Regex(@"(?:\[\@t\=)(.*?)(?:\|)(?:\d{1,7})(?:\|)(\d{1,3}|-\d{1,3})(?:\|)(\d{1,3}|-\d{1,3})");
                            Regex rgxHarvesterType = new Regex(@"(\[\@i\=\d{1,2}\|\d{1,3}\])");
                            Regex rgxItemIllyCode = new Regex(@"(\[\@c\=.{1,4})");
                            Regex rgxItemQtyOnGrid = new Regex(@"(?:\.\s)(\d*)(?:\s)(?:are left on the square.)");

                            //REGEX Strings for Notifications
                            //Regex rgxHarvesterType = new Regex(@"\[@i=.{1,6}");
                            //Regex rgxCityName = new Regex(@"(?<=\[@t=)(.*?)(?=\|)");
                            //Regex rgxGridsAndRegionID = new Regex(@"(?<=\|)(\d{1,3}?)(?=\|)|(?<=\=)(\d{3}?)(?=\|)");
                            //Regex rgxItemIllyCode = new Regex(@"\[@c=.{1,4}");
                            //Regex rgxItemQtyOnGrid = new Regex(@"(\.\s)(\d*)(\s)");

                            //Check to make sure only Miner units (need to populate Rare Herbs)
                            MatchCollection harvesterCodeMatches = rgxHarvesterType.Matches(notificationDetail);
                            string harvesterIllyCode = harvesterCodeMatches[0].Value;

                            //Assemble RegEx Match Collections & Associated Groups
                            Match cityMatches = rgxCityNameAndXyGrid.Match(notificationDetail);
                                Group gCityName = cityMatches.Groups[1];
                                Group gCityXGrid = cityMatches.Groups[2];
                                Group gCityYGrid = cityMatches.Groups[3];

                            Match gridAndRegionMatches = rgxItemXyAndRegionID.Match(notificationDetail);
                                Group gItemXGrid = gridAndRegionMatches.Groups[1];
                                Group gItemYGrid = gridAndRegionMatches.Groups[2];
                                Group gRegionID = gridAndRegionMatches.Groups[3];

                            Match itemIllyCodeMatches = rgxItemIllyCode.Match(notificationDetail);
                                Group gItemCode = itemIllyCodeMatches.Groups[1];

                            Match itemQtyOnGridMatches = rgxItemQtyOnGrid.Match(notificationDetail);
                                Group gQtyOnGrid = itemQtyOnGridMatches.Groups[1];

                            // Create a List Object to store RegExResults
                            var regExResults = new RegExList();

                            //If Unit Code is of a Miner - Continue
                            if (harvesterIllyCode.Contains(humanMiner) || harvesterIllyCode.Contains(elvenMiner) ||
                                harvesterIllyCode.Contains(dwarvenMiner) || harvesterIllyCode.Contains(orcMiner) ||
                                harvesterIllyCode.Contains(humanHerbalist) || harvesterIllyCode.Contains(elvenHerbalist) ||
                                harvesterIllyCode.Contains(dwarvenHerbalist) || harvesterIllyCode.Contains(orcHerbalist))
                            {
                                if (gItemCode.Value == null)
                                {
                                    continue;
                                }
                                else 
                                {
                                    var ListOfViableMineralCodes = (from m in context.RareMinerals
                                                                    select new { m.IllyCode }).ToList();
                                    var ListOfViableHerbCodes = (from h in context.RareHerbs
                                                                 select new { h.IllyCode }).ToList();

                                    bool IsMineral = ListOfViableMineralCodes.Any(item => item.IllyCode == gItemCode.Value);
                                    bool IsHerb = ListOfViableHerbCodes.Any(item => item.IllyCode == gItemCode.Value);

                                    if (IsMineral || IsHerb)
                                    {

                                        //Debug Console WriteLines
                                        Console.WriteLine("CityName:" + gCityName);
                                        Console.WriteLine("CityGridX:" + gCityXGrid);
                                        Console.WriteLine("CityGridY" + gCityYGrid);
                                        Console.WriteLine("ItemGridX:" + gItemXGrid);
                                        Console.WriteLine("ItemGridY:" + gItemYGrid);
                                        Console.WriteLine("RegionID" + gRegionID);
                                        Console.WriteLine("ItemIllyCode" + gItemCode);

                                        // Check if there is anything left on Grid
                                        if (gQtyOnGrid == null)
                                        {
                                            regExResults.ItemGridQty = "0";

                                        }
                                        else
                                        {
                                            regExResults.ItemGridQty = gQtyOnGrid.Value;
                                        }

                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }

                            }
                            else
                            {
                                continue;
                            }

                            if (harvesterIllyCode.Contains(humanMiner) || harvesterIllyCode.Contains(elvenMiner) ||
                                harvesterIllyCode.Contains(dwarvenMiner) || harvesterIllyCode.Contains(orcMiner))
                            {
                                itemCategory = "MINR";
                            }
                            else if (harvesterIllyCode.Contains(humanHerbalist) || harvesterIllyCode.Contains(elvenHerbalist) ||
                                     harvesterIllyCode.Contains(dwarvenHerbalist) || harvesterIllyCode.Contains(orcHerbalist))
                            {
                                itemCategory = "HERB";
                            }

                            var InsertOrUpddateNotify = new illyData[]
                            {
                                // Data to Add for Notification
                                new illyData
                                {

                                    APINotificationID = Int32.Parse(notificationID),
                                    APINotificationTypeID = Int32.Parse(notificationTypeID),
                                    APINotificationCategoryID = Int32.Parse(notificationCategoryID),
                                    APINotificationCategory = notificationCategory,
                                    NotificationDate = notificationOccurrence,
                                    APINotificationType = "NOTI",
                                    ItemCategory = itemCategory,
                                    CityName = gCityName.Value, 
                                    CityXGrid = gCityXGrid.Value, 
                                    CityYGrid = gCityYGrid.Value, 
                                    ItemXGrid = gItemXGrid.Value, 
                                    ItemYGrid = gItemYGrid.Value, 
                                    IllyRegionID = Int32.Parse(gRegionID.Value), 
                                    IllyriadCode = gItemCode.Value, 
                                    GridQuantity = regExResults.ItemGridQty,
                                }

                            };

                            context.IllyAPIData.AddRange(InsertOrUpddateNotify);
                            //context.SaveChanges();

                        }

                        else
                        {
                            string wrongTypeID = xNotify.Element("notificationtype").Attribute("id").Value;
                            Console.WriteLine("Skipping Notification ID: " + notificationID + ". " + "Notification Type ID: " + wrongTypeID);
                            Console.WriteLine("");
                        }

                    }

                    context.SaveChanges();

                }

            }

        }

    }
}
