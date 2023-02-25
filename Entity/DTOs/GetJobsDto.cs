using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class GetJobDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
        public string JobInformation { get; set; }
        public string CompanyName { get; set; }
    }
}
