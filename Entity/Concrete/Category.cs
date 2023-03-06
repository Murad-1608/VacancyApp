namespace Entity.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<SubCategory> Categories { get; set; }
    }
}
