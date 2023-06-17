using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IEducationService:IGenericService<Education>
    {
        IDataResult<Education> GetByName(string name);
    }
}
