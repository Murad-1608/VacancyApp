using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal cityDal;
        public CityManager(ICityDal cityDal)
        {
            this.cityDal = cityDal;
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(cityDal.GetAll());
        }
    }
}
