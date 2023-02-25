using Core.Utilities.Results;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IJobService
    {
        IDataResult<List<GetJobDto>> GetJobs();
        IDataResult<JobDetailDto> JobDetail(int id);
    }
}
