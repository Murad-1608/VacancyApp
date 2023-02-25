using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Education : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
