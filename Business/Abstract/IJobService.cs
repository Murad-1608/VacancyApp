using Core.Utilities.Results;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IJobService:IGenericService<GetJobDto>
    {
        IDataResult<JobDetailDto> JobDetail(int id);
        IDataResult<List<GetJobDto>> GetJobs(string Name);
        IDataResult<List<GetJobDto>> Filter(int typeId, int categoryId, int experienceId, int educationId, int cityId, string keywords);
    }
}
