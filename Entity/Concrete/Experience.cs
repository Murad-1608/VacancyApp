using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Experience : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
