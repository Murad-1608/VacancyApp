using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models.ViewModels
{
    public class JobViewModel
    {
        public AddJobDto AddJobDto { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<SelectListItem> Educations { get; set; }
        public List<SelectListItem> JobTypes { get; set; }
        public List<SelectListItem> Experience { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}
