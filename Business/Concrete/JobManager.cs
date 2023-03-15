using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class JobManager : IJobService
    {
        private readonly IJobDal jobDal;
        public JobManager(IJobDal jobDal)
        {
            this.jobDal = jobDal;
        }

        public IDataResult<List<GetJobDto>> GetAll()
        {
            return new SuccessDataResult<List<GetJobDto>>(jobDal.GetJobsWithCity());
        }

        public IDataResult<JobDetailDto> JobDetail(int id)
        {
            //Add();

            var value = jobDal.JobDetail(id);
            return new SuccessDataResult<JobDetailDto>(value);
        }

        public IDataResult<List<GetJobDto>> GetJobs(string Name)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GetJobDto>> Filter(int typeId, int categoryId, int experienceId, int educationId, int cityId, string keywords)
        {
            var jobs = jobDal.GetJobsWithCity(x => x.JobTypeId == typeId ||
                                                   x.SubCategoryId == categoryId ||
                                                   x.ExperienceId == experienceId ||
                                                   x.EducationId == educationId ||
                                                   x.CityId == cityId ||
                                                   x.Requirements.Contains(keywords) ||
                                                   x.JobInformation.Contains(keywords) ||
                                                   x.Name.Contains(keywords));

            return new SuccessDataResult<List<GetJobDto>>(jobs);
        }

        [ValidationAspect(typeof(JobValidator))]
        public IResult Add(Job job)
        {
            ValidationTool.Validate(new JobValidator(), job);

            return new SuccessResult("Ugurla");
        }
    }
}
