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

        public IDataResult<List<SubCategory>> GetAll()
        {
            return new SuccessDataResult<List<SubCategory>>(subCategoryDal.GetAll());
        }
    }
}
