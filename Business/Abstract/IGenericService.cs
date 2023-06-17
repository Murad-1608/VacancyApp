using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IGenericService<T>
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T value);
    }
}
