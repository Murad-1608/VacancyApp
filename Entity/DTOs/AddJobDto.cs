using Core.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class AddJobDto:IDto
    {
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public int SubCategoryId { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public int EducationId { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Person { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public double MinSalary { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public double MaxSalary { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public int ExperienceId { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public int JobTypeId { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Requirements { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string JobInformation { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public byte MinAge { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public byte MaxAge { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string PhoneNumber { get; set; }
    }
}
