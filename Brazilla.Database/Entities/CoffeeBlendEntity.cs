using Brazilla.Database.Enums;

namespace Brazilla.Database.Entities
{
    public class CoffeeBlendEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public int Left { get; set; }
        public bool IsBuyed { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public long? UserFK { get; set; }
        public UserEntity User { get; set; }
        
        public long? TypeFK { get; set; }
        public BlendTypeEntity Type { get; set; }
    }
}