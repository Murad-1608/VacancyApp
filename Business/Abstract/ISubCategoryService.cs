using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ISubCategoryService : IGenericService<SubCategory>
    {
        IDataResult<SubCategory> GetByName(string name);
    }

}
