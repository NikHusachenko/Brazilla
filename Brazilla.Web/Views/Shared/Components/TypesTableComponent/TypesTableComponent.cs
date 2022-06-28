using Brazilla.Services.BlendTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Views.Shared.Components.TypesTableComponent
{
    public class TypesTableComponent : ViewComponent
    {
        private readonly IBlendTypeService _blendTypeService;

        public TypesTableComponent(IBlendTypeService blendTypeService)
        {
            _blendTypeService = blendTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            TypesTableViewModel vm = new TypesTableViewModel() { Types = _blendTypeService.GetAll(), };
            return View(vm);
        }
    }
}
