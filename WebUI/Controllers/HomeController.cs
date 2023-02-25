using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobService jobService;
        public HomeController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        public IActionResult Index()
        {
            //var httpClient = new HttpClient();
            //var responseMessage = await httpClient.GetAsync("https://localhost:44311/api/Jobs/Get");
            //var jsonString = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<GetJobsModel>>(jsonString);

            var values = jobService.GetJobs().Data;

            return View(values);
        }
    }
}
