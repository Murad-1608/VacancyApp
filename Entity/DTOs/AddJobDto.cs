using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class AddJobDto : IDto
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int SubCategoryId { get; set; }
        public int EducationId { get; set; }
        public string Person { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
        public int ExperienceId { get; set; }
        public int CityId { get; set; }
        public int JobTypeId { get; set; }
        public string Requirements { get; set; }
        public string JobInformation { get; set; }
        public byte MinAge { get; set; }
        public byte MaxAge { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
