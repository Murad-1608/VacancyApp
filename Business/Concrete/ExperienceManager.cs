using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceDal experienceDal;
        public ExperienceManager(IExperienceDal experienceDal)
        {
            this.experienceDal = experienceDal;
        }

        public IResult Add(Experience value)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Experience>> GetAll()
        {
            return new SuccessDataResult<List<Experience>>(experienceDal.GetAll());
        }

        public IDataResult<Experience> GetByName(string name)
        {
            return new SuccessDataResult<Experience>(experienceDal.Get(x => x.Name == name));
        }
    }
}
