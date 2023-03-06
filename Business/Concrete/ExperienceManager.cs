using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        public IDataResult<List<Experience>> GetAll()
        {
            return new SuccessDataResult<List<Experience>>(experienceDal.GetAll());
        }
    }
}
