using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using IllyriadAssist.Data;
using IllyriadAssist.Models;
using Microsoft.EntityFrameworkCore;

namespace IllyriadAssist
{
    public class NotificationDTO
    {

    }
    public class Utilities
    {
        //Function to Disassemble Harvester Notifications
        static void DisassembleHarvestNotify(string notifyText)
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

            //If Unit Code is of a Miner - Continue
            if (harvesterIllyCode.Contains(humanMiner) || harvesterIllyCode.Contains(elvenMiner) ||
                harvesterIllyCode.Contains(dwarvenMiner) || harvesterIllyCode.Contains(orcMiner))
            {
                //Assemble RegEx Match Collections
                MatchCollection cityMatches = rgxCityName.Matches(notifyText);
                MatchCollection gridAndRegionMatches = rgxGridsAndRegionID.Matches(notifyText);
                MatchCollection itemIllyCodeMatches = rgxItemIllyCode.Matches(notifyText);
                MatchCollection itemQtyOnGridMatches = rgxItemQtyOnGrid.Matches(notifyText);

                //Link Individual Matches with Variables (Replace with DB Inserts)
                string cityName = cityMatches[0].Value;
                string cityGridX = gridAndRegionMatches[0].Value;
                string cityGridY = gridAndRegionMatches[1].Value;
                string itemGridX = gridAndRegionMatches[7].Value;
                string itemGridY = gridAndRegionMatches[8].Value;
                string illyRegionID = gridAndRegionMatches[9].Value;
                string itemIllyCode = itemIllyCodeMatches[0].Value;

                //Bug Checking WriteLines (Remove or comment out)
                Console.WriteLine(cityName);
                Console.WriteLine(cityGridX + "|" + cityGridY);
                Console.WriteLine(itemGridX + "|" + itemGridY);
                Console.WriteLine(illyRegionID);
                Console.WriteLine(itemIllyCode);

                // Check if there is anything left on Grid
                if (itemQtyOnGridMatches.Count > 0)
                {
                    string itemQtyOnGrid = itemQtyOnGridMatches[0].Value.Substring(2).Trim();
                    Console.WriteLine(itemQtyOnGrid);
                }
                else
                {
                    string itemQtyOnGrid = "0";
                    Console.WriteLine(itemQtyOnGrid);
                }

            }

        }

        //Function to Parse Illyriad's XML
        static void XMLParser()
        {

            // WIP ----------------------------------------->
            var context = new APISettings();
            {
                var apiKey = context.APIKey
                        .Where(a => a.APIType == "NOTI")
                        .Select(a => new {a.APIKey});
                
            }
            // WIP ----------------------------------------->

            String URLString = "https://elgea.illyriad.co.uk/external/notificationsapi/elgea-NOTIF-AQAAACYJ4FPt1gclDBjwN8Td0SM18meND-A19hm6z_35xzZD9knARdCfbM72eNBFYOD3zj88QePn6CKHyP882nPuJl8=";
            var client = new WebClient();
            var xml = client.DownloadString(URLString);
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

                            Console.WriteLine("Notification Type ID: " + notificationTypeID);
                            Console.WriteLine("Notification Category ID: " + notificationCategoryID);
                            Console.WriteLine("Notification Category: " + notificationCategory);
                            Console.WriteLine("Notification Detail: " + notificationDetail);
                            Console.WriteLine("Notification Occurrence: " + notificationOccurrence);
                            Console.WriteLine("");

                        }
                        else
                        {
                            string wrongTypeID = xNotify.Element("notificationtype").Attribute("id").Value;
                            Console.WriteLine("Skipping Notification ID: " + notificationID + ". " + "Notification Type ID: " + wrongTypeID);
                            Console.WriteLine("");
                        }


                    }

                }

            }


            //Steve's Solution
            //foreach (XElement element in xElementList)
            //{
            //if (element.HasElements)
            //{
            //if(element.Element("notification").Where(p => p.Element("notification").Attribute("id").Value == "45"))

        }
    }
}
