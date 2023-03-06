using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class JobSeeker : BaseEntity, IEntity
    {
        public string Name { get; set; } 
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public int CategoryId { get; set; }
        public int ExperienceId { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Education { get; set; }        
        public string Skills { get; set; } 
        public string About { get; set; }
        public bool IsActive { get; set; }

        public City City { get; set; }
        public Category Category { get; set; }
        public Experience Experience { get; set; }

    }
}
