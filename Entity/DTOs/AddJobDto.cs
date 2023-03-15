using Core.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class AddJobDto:IDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        public int EducationId { get; set; }
        [Required]
        public string Person { get; set; }
        [Required]
        public double MinSalary { get; set; }
        [Required]
        public double MaxSalary { get; set; }
        [Required]
        public int ExperienceId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int JobTypeId { get; set; }
        [Required]
        public string Requirements { get; set; }
        [Required]
        public string JobInformation { get; set; }
        [Required]
        public byte MinAge { get; set; }
        [Required]
        public byte MaxAge { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
