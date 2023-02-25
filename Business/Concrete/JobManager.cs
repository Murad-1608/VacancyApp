using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using static Azure.Core.HttpHeader;

namespace Business.Concrete
{
    public class JobManager : IJobService
    {
        private readonly IJobDal jobDal;
        public JobManager(IJobDal jobDal)
        {
            this.jobDal = jobDal;
        }

        public IDataResult<List<GetJobDto>> GetJobs()
        {
            var jobs = jobDal.GetAll();

            List<GetJobDto> getJobDtos = new List<GetJobDto>();
            foreach (var item in jobs)
            {
                GetJobDto getJobDto = new GetJobDto();

                getJobDto.Id = item.Id;
                getJobDto.Name = item.Name;
                getJobDto.MinSalary = item.MinSalary;
                getJobDto.MaxSalary = item.MaxSalary;
                getJobDto.JobInformation = item.JobInformation;
                getJobDto.CompanyName = item.CompanyName;
                getJobDto.Id = item.Id;

                getJobDtos.Add(getJobDto);
            }

            return new SuccessDataResult<List<GetJobDto>>(getJobDtos);
        }

        public IDataResult<JobDetailDto> JobDetail(int id)
        {
            //Add();

            var value = jobDal.JobDetail(id);
            return new SuccessDataResult<JobDetailDto>(value);
        }

        public void Add()
        {
            Job job = new Job();
            job.MaxAge = 12;
            job.MinAge = 23;
            job.Requirements = "Test1 \n Test2";
            job.CompanyName = "Nadir";
            job.CategoryId = 1;
            job.Person = "Murad";
            job.MinSalary = 12;
            job.MaxSalary = 12;
            job.Name = "Name";
            job.JobInformation = "dfdf";
            job.Email = "dfdf";
            job.CityId = 1;
            job.EducationId = 1;
            job.ExperienceId = 1;
            job.JobTypeId = 1;
            job.PhoneNumber = "vcvcv";

            Console.WriteLine(job.Requirements);

            jobDal.Add(job);
        }
    }
}
