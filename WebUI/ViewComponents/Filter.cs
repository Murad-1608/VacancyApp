using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class Filter : ViewComponent
    {
        private readonly ITypeService typeService;
        private readonly ICategoryService categoryService;
        private readonly IExperienceService experienceService;
        private readonly ISubCategoryService subCategoryService;
        private readonly ICityService cityService;
        private readonly IEducationService educationService;
        public Filter(ITypeService typeService, ICategoryService categoryService, IExperienceService experienceService, ISubCategoryService subCategoryService, ICityService cityService, IEducationService educationService)
        {
            this.typeService = typeService;
            this.categoryService = categoryService;
            this.experienceService = experienceService;
            this.subCategoryService = subCategoryService;
            this.cityService = cityService;
            this.educationService = educationService;
        }

        public IViewComponentResult Invoke()
        {
            FilterDto filterDto = new FilterDto();

            filterDto.Types = typeService.GetAll().Data;
            filterDto.Categories = categoryService.GetAll().Data;
            filterDto.Experiences = experienceService.GetAll().Data;
            filterDto.SubCategories = subCategoryService.GetAll().Data;
            filterDto.Cities = cityService.GetAll().Data;
            filterDto.Educations = educationService.GetAll().Data;


            return View(filterDto);
        }
    }
}
