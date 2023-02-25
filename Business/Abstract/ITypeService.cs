using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ITypeService
    {
        IDataResult<List<JobType>> GetAll();
    }
}
