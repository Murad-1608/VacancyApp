using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            categoryDal.Add(category);

            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(categoryDal.GetAll());
        }

        public IDataResult<Category> GetByName(string name)
        {
            return new SuccessDataResult<Category>(categoryDal.Get(x => x.Name == name));
        }
    }
}
