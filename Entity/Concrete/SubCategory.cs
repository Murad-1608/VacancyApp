using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class SubCategory : BaseEntity, IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public Category Category { get; set; } 
    }
}
