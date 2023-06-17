using Castle.Components.DictionaryAdapter.Xml;
using Entity.Concrete;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebBot.GetValuesBot;
using WebBot.ViewModels;

namespace WebBot.Commands
{
    public class GetDataCommand : BaseCommand
    {
        private readonly HomeWindowViewModel viewModel;

        public GetDataCommand(HomeWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override async void Execute(object? parameter)
        {

            List<Job> jobs = new List<Job>();
            Bot bot = new Bot();


            for (int i = 1; i < 2; i++)
            {
                Job job = new Job();
                string href = bot.Urls("https://boss.az/vacancies?utf8=%E2%9C%93&search%5Bcompany_id%5D=&search%5Bcategory_id%5D=&search%5Bregion_id%5D=&search%5Bsalary%5D=&search%5Beducation_id%5D=&search%5Bexperience_id%5D=&search%5Bkeyword%5D=&commit=Axtar", "/html/body/div[4]/div[2]/div/div[" + i + "]/div[1]/a", "href");
                job.Name = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[2]/div[1]/h1");
                job.CompanyName = $"{bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[2]/div[1]/a")}".Replace("&quot;", "'");
                job.SubCategoryId = viewModel.SubCategoryService.GetByName(bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[1]/a[2]")).Data.Id;

                string education = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[3]/div[2]");
                if (education == string.Empty)
                {
                    education = "-";
                }

                job.EducationId = viewModel.EducationService.GetByName(education).Data.Id;
                job.CityId = viewModel.CityService.GetByName(bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[1]/div[2]")).Data.Id;
                job.ExperienceId = viewModel.ExperienceService.GetByName(bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[4]/div[2]")).Data.Id;
                job.Requirements = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[6]/div[2]/dd/p");
                job.JobInformation = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[6]/div[1]/dd/p");

                job.Email = await GetEmail("https://boss.az" + href);

                job.PhoneNumber = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[2]/ul/li[1]/div[2]/a[1]");
                job.IsActive = true;
                job.IsPremium = false;



                //Date

                string date = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[5]/div[2]");
                string[] dateSplit = date.Split(' ');
                int month = 0;
                if (dateSplit[0] == "Yanvar")
                    month = 1;
                else if (dateSplit[0] == "Fevral")
                    month = 2;
                else if (dateSplit[0] == "Mart")
                    month = 3;
                else if (dateSplit[0] == "Aprel")
                    month = 4;
                else if (dateSplit[0] == "May")
                    month = 5;
                else if (dateSplit[0] == "İyun")
                    month = 6;
                else if (dateSplit[0] == "İyul")
                    month = 7;
                else if (dateSplit[0] == "Avqust")
                    month = 8;
                else if (dateSplit[0] == "Sentyabr")
                    month = 9;
                else if (dateSplit[0] == "Oktyabr")
                    month = 10;
                else if (dateSplit[0] == "Noyabr")
                    month = 11;
                else if (dateSplit[0] == "Dekabr")
                    month = 12;

                DateTime result = new DateTime(Convert.ToInt32(dateSplit[2]), month, Convert.ToInt32(dateSplit[1].Remove(dateSplit[1].Length - 1)));

                job.CreateDate = result;

                //End date
                string Enddate = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[6]/div[2]");
                string[] EndDateSplit = Enddate.Split(' ');
                int EndMonth = 0;
                if (EndDateSplit[0] == "Yanvar")
                    EndMonth = 1;
                else if (EndDateSplit[0] == "Fevral")
                    EndMonth = 2;
                else if (EndDateSplit[0] == "Mart")
                    EndMonth = 3;
                else if (EndDateSplit[0] == "Aprel")
                    EndMonth = 4;
                else if (EndDateSplit[0] == "May")
                    EndMonth = 5;
                else if (EndDateSplit[0] == "İyun")
                    EndMonth = 6;
                else if (EndDateSplit[0] == "İyul")
                    EndMonth = 7;
                else if (EndDateSplit[0] == "Avqust")
                    EndMonth = 8;
                else if (EndDateSplit[0] == "Sentyabr")
                    EndMonth = 9;
                else if (EndDateSplit[0] == "Oktyabr")
                    EndMonth = 10;
                else if (EndDateSplit[0] == "Noyabr")
                    EndMonth = 11;
                else if (EndDateSplit[0] == "Dekabr")
                    EndMonth = 12;

                DateTime EndDateResult = new DateTime(Convert.ToInt32(EndDateSplit[2]), EndMonth, Convert.ToInt32(EndDateSplit[1].Remove(EndDateSplit[1].Length - 1)));

                job.EndDate = EndDateResult;




                //Get salary
                string salary = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[2]/div[1]/span");

                if (salary == "-")
                {
                    job.MinSalary = null;
                    job.MaxSalary = null;
                }
                else
                {
                    string[] salarySplit = salary.Split(' ');
                    if (salarySplit.Length == 2)
                    {
                        job.MinSalary = Convert.ToInt32(salarySplit[0]);
                        job.MaxSalary = Convert.ToInt32((salarySplit[0]));
                    }
                    else
                    {
                        job.MinSalary = Convert.ToInt32(salarySplit[0]);
                        job.MaxSalary = Convert.ToInt32(salarySplit[2]);
                    }

                }
                //Age
                string age = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[2]/div[2]");
                string[] ageSplit = age.Split(' ');

                if (ageSplit.Length == 3)
                {
                    job.MinAge = Convert.ToByte(ageSplit[1]);
                    job.MaxAge = Convert.ToByte(ageSplit[1]);
                }
                else
                {
                    job.MinAge = Convert.ToByte(ageSplit[0]);
                    job.MaxAge = Convert.ToByte(ageSplit[2]);
                }



                viewModel.JobService.AddJob(job);

                viewModel.GetValueCount += 1;
            }

            for (int i = 2; i < 20; i++)
            {
                string page = "https://boss.az/vacancies?action=index&controller=vacancies&only_path=true&page=" + i + "&search%5Bcategory_id%5D=&search%5Bcompany_id%5D=&search%5Beducation_id%5D=&search%5Bexperience_id%5D=&search%5Bkeyword%5D=&search%5Bregion_id%5D=&search%5Bsalary%5D=&type=vacancies";

                for (int j = 1; j < 21; j++)
                {
                    Job job = new Job();
                    string href = bot.Urls(page, "/html/body/div[4]/div[2]/div/div[" + j + "]/div[1]/a", "href");
                    job.Name = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[2]/div[1]/h1");
                    job.CompanyName = $"{bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[2]/div[1]/a")}".Replace("&quot;", "'");
                    job.SubCategoryId = viewModel.SubCategoryService.GetByName(bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[1]/a[2]")).Data.Id;

                    string education = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[3]/div[2]");
                    if (education == string.Empty)
                    {
                        education = "-";
                    }
                    job.EducationId = viewModel.EducationService.GetByName(education).Data.Id;
                    job.CityId = viewModel.CityService.GetByName(bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[1]/div[2]")).Data.Id;
                    job.ExperienceId = viewModel.ExperienceService.GetByName(bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[4]/div[2]")).Data.Id;
                    job.Requirements = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[6]/div[2]/dd/p");
                    job.JobInformation = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[6]/div[1]/dd/p");
                    job.Email = bot.Urls("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[2]/ul/li[2]/div[2]/a", "href");
                    job.PhoneNumber = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[2]/ul/li[1]/div[2]/a[1]");
                    job.IsActive = true;
                    job.IsPremium = false;



                    //Date

                    string date = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[5]/div[2]");
                    string[] dateSplit = date.Split(' ');
                    int month = 0;
                    if (dateSplit[0] == "Yanvar")
                        month = 1;
                    else if (dateSplit[0] == "Fevral")
                        month = 2;
                    else if (dateSplit[0] == "Mart")
                        month = 3;
                    else if (dateSplit[0] == "Aprel")
                        month = 4;
                    else if (dateSplit[0] == "May")
                        month = 5;
                    else if (dateSplit[0] == "İyun")
                        month = 6;
                    else if (dateSplit[0] == "İyul")
                        month = 7;
                    else if (dateSplit[0] == "Avqust")
                        month = 8;
                    else if (dateSplit[0] == "Sentyabr")
                        month = 9;
                    else if (dateSplit[0] == "Oktyabr")
                        month = 10;
                    else if (dateSplit[0] == "Noyabr")
                        month = 11;
                    else if (dateSplit[0] == "Dekabr")
                        month = 12;

                    DateTime result = new DateTime(Convert.ToInt32(dateSplit[2]), month, Convert.ToInt32(dateSplit[1].Remove(dateSplit[1].Length - 1)));

                    job.CreateDate = result;

                    //End date
                    string Enddate = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[6]/div[2]");
                    string[] EndDateSplit = Enddate.Split(' ');
                    int EndMonth = 0;
                    if (EndDateSplit[0] == "Yanvar")
                        EndMonth = 1;
                    else if (EndDateSplit[0] == "Fevral")
                        EndMonth = 2;
                    else if (EndDateSplit[0] == "Mart")
                        EndMonth = 3;
                    else if (EndDateSplit[0] == "Aprel")
                        EndMonth = 4;
                    else if (EndDateSplit[0] == "May")
                        EndMonth = 5;
                    else if (EndDateSplit[0] == "İyun")
                        EndMonth = 6;
                    else if (EndDateSplit[0] == "İyul")
                        EndMonth = 7;
                    else if (EndDateSplit[0] == "Avqust")
                        EndMonth = 8;
                    else if (EndDateSplit[0] == "Sentyabr")
                        EndMonth = 9;
                    else if (EndDateSplit[0] == "Oktyabr")
                        EndMonth = 10;
                    else if (EndDateSplit[0] == "Noyabr")
                        EndMonth = 11;
                    else if (EndDateSplit[0] == "Dekabr")
                        EndMonth = 12;

                    DateTime EndDateResult = new DateTime(Convert.ToInt32(EndDateSplit[2]), EndMonth, Convert.ToInt32(EndDateSplit[1].Remove(EndDateSplit[1].Length - 1)));

                    job.EndDate = EndDateResult;




                    //Get salary
                    string salary = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[2]/div[1]/span");
                    if (salary == "—")
                    {
                        job.MinSalary = null;
                        job.MaxSalary = null;
                    }
                    else
                    {
                        string[] salarySplit = salary.Split(' ');
                        if (salarySplit.Length == 2)
                        {
                            job.MinSalary = Convert.ToInt32(salarySplit[0]);
                            job.MaxSalary = Convert.ToInt32((salarySplit[0]));
                        }
                        else
                        {
                            job.MinSalary = Convert.ToInt32(salarySplit[0]);
                            job.MaxSalary = Convert.ToInt32(salarySplit[2]);
                        }

                    }
                    //Age
                    string age = bot.GetValues("https://boss.az" + href, "/html/body/div[3]/div[1]/div[5]/div/div[1]/ul/li[2]/div[2]");
                    string[] ageSplit = age.Split(' ');

                    if (ageSplit.Length == 3)
                    {
                        job.MinAge = Convert.ToByte(ageSplit[1]);
                        job.MaxAge = Convert.ToByte(ageSplit[1]);
                    }
                    else
                    {
                        job.MinAge = Convert.ToByte(ageSplit[0]);
                        job.MaxAge = Convert.ToByte(ageSplit[2]);
                    }


                    viewModel.JobService.AddJob(job);

                    viewModel.GetValueCount += 1;
                }
            }

            MessageBox.Show("Uğurla yekunlaşdı");
        }
        public string Decode()
        {
            string value = "W2VtYWlsJiMxNjA7cHJvdGVjdGVkXQ==";

            byte[] encodedBytes = System.Convert.FromBase64String(value);

            return System.Text.Encoding.UTF8.GetString(encodedBytes);
        }


        public async Task<string> GetEmail(string url)
        {
            HttpClient httpClient = new HttpClient();

            // Send GET request to website
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            // Parse HTML content with HtmlAgilityPack
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);

            // Select elements containing email addresses
            var emailElements = htmlDoc.DocumentNode.SelectNodes("/html/body/div[3]/div[1]/div[5]/div/div[2]/ul/li[2]/div[2]/a");
            if (emailElements != null)
            {
                foreach (var emailElement in emailElements)
                {
                    // Extract email address from element
                    var email = emailElement.Attributes["href"].Value.Replace("mailto:", "");

                    return email;
                }
            }
            return null;
        }


    }
}

