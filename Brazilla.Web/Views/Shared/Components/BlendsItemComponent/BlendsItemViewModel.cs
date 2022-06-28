using Brazilla.Database.Entities;

namespace Brazilla.Web.Views.Shared.Components.BlendsItemComponent
{
    public class BlendsItemViewModel
    {
        public CoffeeBlendEntity Blend { get; set; }
        public long? buyerId { get; set; }
    }
}
