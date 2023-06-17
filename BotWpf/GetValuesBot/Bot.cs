using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebBot.GetValuesBot
{
    public class Bot
    {
        public string html;
        public Uri url;

        public string GetValues(string Url, string XPath)
        {
            string value;

            try
            {
                url = new Uri(Url);

            }
            catch (Exception)
            {

                throw;
            }

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                html = client.DownloadString(url);
            }
            catch (Exception)
            {

                throw;
            }


            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            try
            {
                value = doc.DocumentNode.SelectSingleNode(XPath).InnerText;
            }
            catch (Exception)
            {
                throw;
            }
            return value;
        }
        public string Urls(string Url, string XPath, string attrubute)
        {
            string href;
            try
            {
                url = new Uri(Url);

            }
            catch (Exception)
            {

                throw;
            }

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                html = client.DownloadString(url);
            }
            catch (Exception)
            {

                throw;
            }


            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            try
            {
                href = doc.DocumentNode.SelectSingleNode(XPath).Attributes[attrubute].Value;
            }
            catch (Exception)
            {

                throw;
            }

            return href;
        }
        public string ExtractEmails(string data)
        {

            //instantiate with this pattern 
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            //find items that matches with our pattern
            MatchCollection emailMatches = emailRegex.Matches(data);

            //StringBuilder sb = new StringBuilder();
            string s = "";
            foreach (Match emailMatch in emailMatches)
            {
                //sb.AppendLine(emailMatch.Value);
                s += emailMatch.Value + ",";
            }
            return s;
        }

    }
}
