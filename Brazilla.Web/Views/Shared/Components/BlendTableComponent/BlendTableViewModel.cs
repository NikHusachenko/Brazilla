using Brazilla.Database.Entities;

namespace Brazilla.Web.Views.Shared.Components.BlendTableComponent
{
    public class BlendTableViewModel
    {
        public List<CoffeeBlendEntity> Blends { get; set; }

        public BlendTableViewModel()
        {
            Blends = new List<CoffeeBlendEntity>();
        }
    }
}
