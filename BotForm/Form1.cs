using System.Net;
using System.Text;

namespace BotForm
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
            GetValues("https://boss.az/vacancies?utf8=%E2%9C%93&search%5Bcompany_id%5D=&search%5Bcategory_id%5D=69&search%5Bregion_id%5D=&search%5Bsalary%5D=&search%5Beducation_id%5D=&search%5Bexperience_id%5D=&search%5Bkeyword%5D=&commit=Axtar", "/html/body/div[4]/div[2]/div/div[1]/a", new List<string>());
        }



        

                                                                                                                                                                                                                                                     // /html/body/div[4]/div[2]/div/div[3]/a

        public void GetValues(string Url, string XPath, List<string> values)
        {
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
                values.Add(doc.DocumentNode.SelectSingleNode(XPath).InnerText);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}