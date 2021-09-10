using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SportResults
{
    class Program
    {
        public static void Main()
        {
            string html;
            // obtain some arbitrary html....
            using (var client = new WebClient())
            {
                html = client.DownloadString("http://www.livescore.cz/");
            }
            // use the html agility pack: http://www.codeplex.com/htmlagilitypack
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            StringBuilder sb = new StringBuilder();
            foreach (HtmlTextNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                sb.AppendLine(node.Text);
            }
            string final = sb.ToString();

            Console.WriteLine(final);
            Console.ReadKey();
        }
    }
}
