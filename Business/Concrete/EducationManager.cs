using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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

        public IResult Add(Education value)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Education>> GetAll()
        {
            return new SuccessDataResult<List<Education>>(educationDal.GetAll());
        }

        public IDataResult<Education> GetByName(string name)
        {
            return new SuccessDataResult<Education>(educationDal.Get(x => x.Name == name));
        }
    }
}
