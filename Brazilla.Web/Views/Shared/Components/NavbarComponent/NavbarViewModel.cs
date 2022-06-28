using Brazilla.Database.Entities;

namespace Brazilla.Web.Views.Shared.Components.NavbarComponent
{
    public class NavbarViewModel
    {
        public bool? IsAdmin { get; set; }
        public bool? IsAuthenticate { get; set; }
        public List<BlendTypeEntity> BlendTypes { get; set; }

        public NavbarViewModel()
        {
            BlendTypes = new List<BlendTypeEntity>();
        }
    }
}
