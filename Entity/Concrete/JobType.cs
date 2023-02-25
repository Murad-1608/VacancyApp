using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class JobType : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
