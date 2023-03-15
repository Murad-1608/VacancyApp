using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;


namespace Bot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string html;
        public Uri url;

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> ages = new List<string>();

            for (int i = 1; i < 9; i++)
            {
                string href = Urls("https://boss.az/vacancies?utf8=%E2%9C%93&search%5Bcompany_id%5D=&search%5Bcategory_id%5D=69&search%5Bregion_id%5D=&search%5Bsalary%5D=&search%5Beducation_id%5D=&search%5Bexperience_id%5D=&search%5Bkeyword%5D=&commit=Axtar", "/html/body/div[4]/div[2]/div/div[" + i + "]/div[1]/a", "href");
                ages.Add(GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[2]/div[2]"));
            }

        }                                                                                                                                                                                                                                                                      ///html/body/div[4]/div[2]/div/div[2]/div[1]/a
        // /html/body/div[4]/div[2]/div/div[3]/a
        /// /html/body/div[4]/div[2]/div/div[8]/a

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

    }
}
