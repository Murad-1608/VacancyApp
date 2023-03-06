using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EducationDal : EfRepositoryBase<Education,AppDbContext>, IEducationDal
    {
    }
}
