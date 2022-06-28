using Brazilla.Services.BlendServices;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Views.Shared.Components.BlendTableComponent
{
    public class BlendTableComponent : ViewComponent
    {
        private readonly IBlendService _blendService;

        public BlendTableComponent(IBlendService blendService)
        {
            _blendService = blendService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            BlendTableViewModel vm = new BlendTableViewModel() { Blends = _blendService.GetAll() };
            return View(vm);
        }
    }
}
