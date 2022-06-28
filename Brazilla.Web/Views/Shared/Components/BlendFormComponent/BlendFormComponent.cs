using Brazilla.Services.BlendTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Views.Shared.Components.BlendFormComponent
{
    public class BlendFormComponent : ViewComponent
    {
        private readonly IBlendTypeService _blendTypeService;

        public BlendFormComponent(IBlendTypeService blendTypeService)
        {
            _blendTypeService = blendTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            BlendFormViewModel vm = new BlendFormViewModel() { Types = _blendTypeService.GetAll() };
            return View(vm);
        }
    }
}
