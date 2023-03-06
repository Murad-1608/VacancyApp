using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class EducationManager : IEducationService
    {
        private readonly IEducationDal educationDal;
        public EducationManager(IEducationDal educationDal)
        {
            this.educationDal = educationDal;
        }

        public IDataResult<List<Education>> GetAll()
        {
            return new SuccessDataResult<List<Education>>(educationDal.GetAll());
        }
    }
}
