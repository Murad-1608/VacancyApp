using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Abstract
{
    public interface IJobDal : IRepositoryBase<Job>
    {
        JobDetailDto JobDetail(int id);
    }
}
