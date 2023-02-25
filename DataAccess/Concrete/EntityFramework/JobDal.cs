using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class JobDal : EfRepositoryBase<Job, AppDbContext>, IJobDal
    {
        public JobDetailDto JobDetail(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var value = context.Jobs.Include(x => x.City).Include(x => x.Category).Include(x => x.Education).Include(x => x.Experience).Include(x => x.JobType).FirstOrDefault(x => x.Id == id);


                return new JobDetailDto()
                {
                    Id = value.Id,
                    City = value.City.Name,
                    Name = value.Name,
                    JobInformation = value.JobInformation,
                    Requirements = value.Requirements,
                    Email = value.Email,
                    PhoneNumber = value.PhoneNumber,
                    MinAge = value.MinAge,
                    MaxAge = value.MaxAge,
                    MinSalary = value.MinSalary,
                    MaxSalary = value.MaxSalary,
                    Experence = value.Experience.Name,
                    CreateDate = value.CreateDate,
                    EndDate = value.EndDate,
                    Person = value.Person,
                    CompanyName = value.CompanyName,
                    Education = value.Education.Name,
                    TypeJob = value.JobType.Name
                };
            }
        }
    }
}
