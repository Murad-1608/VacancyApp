using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService jobService;
        public JobController(IJobService jobService)
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


        public IActionResult Details(int id)
        {
            var job = jobService.JobDetail(id).Data;

            return View(job);
        }

        [HttpPost]
        public IActionResult Add(string description)
        {           

            return View();
        }
    }
}
