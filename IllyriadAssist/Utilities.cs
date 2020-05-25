using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using IllyriadAssist.Data;
using IllyriadAssist.Models;

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

            //REGEX Strings for Notifications
            Regex rgxHarvesterType = new Regex(@"\[@i=.{1,6}");
            Regex rgxCityName = new Regex(@"(?<=\[@t=)(.*?)(?=\|)");
            Regex rgxGridsAndRegionID = new Regex(@"(?<=\|)(\d{1,3}?)(?=\|)|(?<=\=)(\d{3}?)(?=\|)");
            Regex rgxItemIllyCode = new Regex(@"\[@c=.{1,4}");
            Regex rgxItemQtyOnGrid = new Regex(@"(\.\s)(\d*)(\s)");

            //Check to make sure only Miner units (need to populate Rare Herbs)
            MatchCollection harvesterCodeMatches = rgxHarvesterType.Matches(notifyText);
            string harvesterIllyCode = harvesterCodeMatches[0].Value;

            // Create a List Object to store RegExResults
            var regExResults = new RegExList();

            //If Unit Code is of a Miner - Continue
            if (harvesterIllyCode.Contains(humanMiner) || harvesterIllyCode.Contains(elvenMiner) ||
                harvesterIllyCode.Contains(dwarvenMiner) || harvesterIllyCode.Contains(orcMiner))
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

                            //var HarvestResults =  DisassembleHarvestNotify(xNotify.Element("notificationdetail").Value);

                            //Illy Miner Harvester Codes
                            string humanMiner = "[@i=5|678]";
                            string elvenMiner = "[@i=5|682]";
                            string dwarvenMiner = "[@i=5|686]";
                            string orcMiner = "[@i=5|690]";

                            //REGEX Strings for Notifications
                            Regex rgxHarvesterType = new Regex(@"\[@i=.{1,6}");
                            Regex rgxCityName = new Regex(@"(?<=\[@t=)(.*?)(?=\|)");
                            Regex rgxGridsAndRegionID = new Regex(@"(?<=\|)(\d{1,3}?)(?=\|)|(?<=\=)(\d{3}?)(?=\|)");
                            Regex rgxItemIllyCode = new Regex(@"\[@c=.{1,4}");
                            Regex rgxItemQtyOnGrid = new Regex(@"(\.\s)(\d*)(\s)");

                            //Check to make sure only Miner units (need to populate Rare Herbs)
                            MatchCollection harvesterCodeMatches = rgxHarvesterType.Matches(notificationDetail);
                            string harvesterIllyCode = harvesterCodeMatches[0].Value;

                            // Create a List Object to store RegExResults
                            var regExResults = new RegExList();

                            //If Unit Code is of a Miner - Continue
                            if (harvesterIllyCode.Contains(humanMiner) || harvesterIllyCode.Contains(elvenMiner) ||
                                harvesterIllyCode.Contains(dwarvenMiner) || harvesterIllyCode.Contains(orcMiner))
                            {
                                //Assemble RegEx Match Collections
                                MatchCollection cityMatches = rgxCityName.Matches(notificationDetail);
                                MatchCollection gridAndRegionMatches = rgxGridsAndRegionID.Matches(notificationDetail);
                                MatchCollection itemIllyCodeMatches = rgxItemIllyCode.Matches(notificationDetail);
                                MatchCollection itemQtyOnGridMatches = rgxItemQtyOnGrid.Matches(notificationDetail);

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
                            else
                            {
                                continue;
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
                                    ItemCategory = "MINR",
                                    CityName = regExResults.CityName, 
                                    CityXGrid = regExResults.CityGridX, 
                                    CityYGrid = regExResults.CityGridY, 
                                    ItemXGrid = regExResults.ItemGridX, 
                                    ItemYGrid = regExResults.ItemGridY, 
                                    IllyRegionID = regExResults.RegionID, 
                                    IllyriadCode = regExResults.ItemIllyCode, 
                                    GridQuantity = regExResults.ItemGridQty,

                                }

                            };

                            context.IllyAPIData.AddRange(InsertOrUpddateNotify);

                        }

                        else
                        {
                            string wrongTypeID = xNotify.Element("notificationtype").Attribute("id").Value;
                            Console.WriteLine("Skipping Notification ID: " + notificationID + ". " + "Notification Type ID: " + wrongTypeID);
                            Console.WriteLine("");
                        }

                        context.SaveChanges();

                    }

                }

            }

        }

    }
}
