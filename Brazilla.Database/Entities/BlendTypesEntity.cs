namespace Brazilla.Database.Entities
{
    public class BlendTypeEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Arabica { get; set; }
        public int Robusta { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public List<CoffeeBlendEntity> Blends { get; set; }
    }
}