using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Entity.DTOs;
using X.PagedList;

namespace WebUI.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService jobService;
        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }
        public IActionResult Index(int page = 1)
        {
            //var httpClient = new HttpClient();
            //var responseMessage = await httpClient.GetAsync("https://localhost:44311/api/Jobs/Get");
            //var jsonString = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<GetJobsModel>>(jsonString);

            var values = jobService.GetAll().Data.ToPagedList(page, 6);

            return View(values);
        }


        public IActionResult Details(int id)
        {
            var job = jobService.JobDetail(id).Data;

            return View(job);
        }

        [HttpPost]
        public IActionResult Filter(int typeId, int categoryId, int experienceId, int educationId, int cityId, string keywords, int page = 1)
        {
            var jobs = jobService.Filter(typeId, categoryId, experienceId, educationId, cityId, keywords).Data.ToPagedList(page, 6);

            return View(jobs);
        }
    }
}
