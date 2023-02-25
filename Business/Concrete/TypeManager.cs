using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class TypeManager : ITypeService
    {
        private readonly ITypeDal typeDal;
        public TypeManager(ITypeDal typeDal)
        {
            this.typeDal = typeDal;
        }
        
        public IDataResult<List<JobType>> GetAll()
        {
            return new SuccessDataResult<List<JobType>>(typeDal.GetAll());
        }
    }
}
