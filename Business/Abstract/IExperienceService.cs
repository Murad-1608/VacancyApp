using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IExperienceService : IGenericService<Experience>
    {
        IDataResult<Experience> GetByName(string name);
    }
}
