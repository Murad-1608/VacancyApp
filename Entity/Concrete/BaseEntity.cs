using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
