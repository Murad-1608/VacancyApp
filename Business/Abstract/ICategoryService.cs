using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        IDataResult<Category> GetByName(string name);
    }
}
