using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.DTOs
{
    public class FilterDto : IDto
    {
        public List<JobType> Types { get; set; }
    }
}
