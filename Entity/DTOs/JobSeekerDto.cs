using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class JobSeekerDetailDto : IDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public string Experience { get; set; }
        public int Age { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Education { get; set; }
        public string Skills { get; set; }
        public string About { get; set; }
    }
}
