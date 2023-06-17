using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.DTOs
{
    public class FilterDto : IDto
    {
        public List<Category> Categories { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<City> Cities { get; set; }
        public List<Education> Educations { get; set; }
    }
}
