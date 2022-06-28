using Brazilla.Database.Enums;

namespace Brazilla.Database.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserTypes Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public List<CoffeeBlendEntity> Blends { get; set; }
    }
}