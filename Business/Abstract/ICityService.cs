using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICityService : IGenericService<City>
    {
        IDataResult<City> GetByName(string name);

    }
}
