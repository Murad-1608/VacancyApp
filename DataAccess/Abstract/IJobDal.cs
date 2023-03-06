using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IJobDal : IRepositoryBase<Job>
    {
        JobDetailDto JobDetail(int id);
        List<GetJobDto> GetJobsWithCity(Expression<Func<Job, bool>> filter = null);
    }
}
