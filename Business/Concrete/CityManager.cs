using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        public IResult Add(City city)
        {
            cityDal.Add(city);

            return new SuccessResult();
        }

        public IDataResult<City> GetByName(string name)
        {
            return new SuccessDataResult<City>(cityDal.Get(x => x.Name == name));

        }
    }
}
