using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class JobDetailDto : IDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Person { get; set; }
        public string Name { get; set; }
        public string JobInformation { get; set; }
        public string Requirements { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte MinAge { get; set; }
        public byte MaxAge { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
        public string Experence { get; set; }
        public string CompanyName { get; set; }
        public string Education { get; set; }
        public string TypeJob { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
