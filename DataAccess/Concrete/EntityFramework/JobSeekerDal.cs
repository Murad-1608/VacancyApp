using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class JobSeekerDal : EfRepositoryBase<JobSeeker, AppDbContext>, IJobSeekerDal
    {
        public List<JobSeekersDto> GetJobSeekerWithCity(Expression<Func<JobSeeker, bool>> filter = null)
        {
            using (AppDbContext context = new())
            {
                var value = filter == null ? context.JobSeekers.Include(x => x.City).Where(x => x.IsActive == true).ToList()
                                           : context.JobSeekers.Include(x => x.City).Where(filter).Where(x => x.IsActive == true).ToList();

                List<JobSeekersDto> getJobSeekersDtos = new List<JobSeekersDto>();

                foreach (var item in value)
                {
                    JobSeekersDto getJobSeekersDto = new JobSeekersDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Salary = item.Salary,
                        CityName = item.City.Name
                    };
                    getJobSeekersDtos.Add(getJobSeekersDto);
                }
                return getJobSeekersDtos;
            }
        }
    }
}
