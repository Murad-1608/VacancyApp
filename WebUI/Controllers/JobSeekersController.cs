using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.Controllers
{
    public class JobSeekersController : Controller
    {
        private readonly IJobSeekerService jobSeekerService;
        public JobSeekersController(IJobSeekerService jobSeekerService)
        {
            this.jobSeekerService = jobSeekerService;
        }

        public IActionResult Index(int page = 1)
        {
            var values = jobSeekerService.GetAll().Data.ToPagedList(page, 6);

            return View(values);
        }
    }
}
