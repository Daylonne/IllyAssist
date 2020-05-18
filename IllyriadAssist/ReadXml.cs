using System;
using System.Xml;
using System.Net;
using System.IO;

namespace IllyriadAssist
{
    public class ReadXml
    {
        static void DownloadXML(string[] args)
        {
            String URLString = "https://elgea.illyriad.co.uk/external/mailapi/elgea-IMAIL-AQAAACjUhE-Q3V1HQVhD6HlHzm_ds4z_FQHo2H3NG_IwiMofDhW6qlDd3GZKkt-Al4871jsQM3p6GZ_4p-K_evKRUIQ=";
            XmlTextReader reader = new XmlTextReader(URLString);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);

                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                        Console.Write(">");
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
        }
    }
}