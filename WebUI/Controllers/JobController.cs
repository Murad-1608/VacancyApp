using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Models;
using WebUI.Models.ViewModels;
using X.PagedList;

namespace WebUI.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService jobService;
        private readonly ICategoryService categoryService;
        private readonly ISubCategoryService subCategoryService;
        private readonly IExperienceService experienceService;
        private readonly ICityService cityService;
        private readonly IEducationService educationService;
        private readonly ITypeService typeService;
        public JobController(IJobService jobService, ICategoryService categoryService, ISubCategoryService subCategoryService, IExperienceService experienceService, ICityService cityService, IEducationService educationService, ITypeService typeService)
        {
            this.jobService = jobService;
            this.categoryService = categoryService;
            this.subCategoryService = subCategoryService;
            this.experienceService = experienceService;
            this.cityService = cityService;
            this.educationService = educationService;
            this.typeService = typeService;
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

        [HttpGet]
        public IActionResult Add()
        {            
            return View(JobViewModel());
        }


        [HttpPost]
        public IActionResult Add(AddJobDto value)
        {

            //if (ModelState.IsValid)
            //{
            //    jobService.Add(value);
            //}
            
            return View();

            
        }

        private JobViewModel JobViewModel()
        {
            List<Category> categories = categoryService.GetAll().Data;

            List<SelectListItem> experiences = (from i in experienceService.GetAll().Data.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Name,
                                                    Value = i.Id.ToString()
                                                }).ToList();

            List<SubCategory> subCategories = subCategoryService.GetAll().Data;

            List<SelectListItem> city = (from i in cityService.GetAll().Data.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.Name,
                                             Value = i.Id.ToString()
                                         }).ToList();

            List<SelectListItem> education = (from i in educationService.GetAll().Data.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.Name,
                                                  Value = i.Id.ToString()
                                              }).ToList();

            List<SelectListItem> type = (from i in typeService.GetAll().Data.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.Name,
                                             Value = i.Id.ToString()
                                         }).ToList();

            JobViewModel viewmodel = new JobViewModel()
            {
                Categories = categories,
                Experience = experiences,
                SubCategories = subCategories,
                Cities = city,
                Educations = education,
                JobTypes = type
            };

            return viewmodel;
        }
    }
}
