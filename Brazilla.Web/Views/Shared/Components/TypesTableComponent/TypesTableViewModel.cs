using Brazilla.Database.Entities;

namespace Brazilla.Web.Views.Shared.Components.TypesTableComponent
{
    public class TypesTableViewModel
    {
        public List<BlendTypeEntity> Types { get; set; }

        public TypesTableViewModel()
        {
            Types = new List<BlendTypeEntity>();
        }
    }
}
