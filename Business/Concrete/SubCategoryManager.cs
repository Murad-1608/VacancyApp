using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly ISubCategoryDal subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            this.subCategoryDal = subCategoryDal;
        }

        public IResult Add(SubCategory value)
        {
            subCategoryDal.Add(value);

            return new SuccessResult();
        }

        public IDataResult<List<SubCategory>> GetAll()
        {
            return new SuccessDataResult<List<SubCategory>>(subCategoryDal.GetAll());
        }

        public IDataResult<SubCategory> GetByName(string name)
        {
            return new SuccessDataResult<SubCategory>(subCategoryDal.Get(x => x.Name == name));
        }
    }
}
