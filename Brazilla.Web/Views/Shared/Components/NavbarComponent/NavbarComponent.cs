using Brazilla.Services.BlendTypeServices;
using Brazilla.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Views.Shared.Components.NavbarComponent
{
    public class NavbarComponent : ViewComponent
    {
        private readonly ICurrentUser _currentUser;
        private readonly IBlendTypeService _blendTypeService;

        public NavbarComponent(ICurrentUser currentUser,
            IBlendTypeService blendTypeService)
        {
            _currentUser = currentUser;
            _blendTypeService = blendTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            NavbarViewModel vm = new NavbarViewModel()
            {
                BlendTypes = _blendTypeService.GetAll(),
                IsAdmin = _currentUser.IsAdmin,
                IsAuthenticate = _currentUser.IsAuthenticated,
            };
            
            return View(vm);
        }
    }
}
