using Brazilla.Database.Entities;

namespace Brazilla.Web.Models.Blend
{
    public class BlendsViewModel
    {
        public List<CoffeeBlendEntity> Blends { get; set; }

        public BlendsViewModel()
        {
            Blends = new List<CoffeeBlendEntity>();
        }
    }
}
