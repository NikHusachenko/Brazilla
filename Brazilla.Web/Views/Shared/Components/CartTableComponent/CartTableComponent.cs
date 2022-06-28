using Brazilla.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Views.Shared.Components.CartTableComponent
{
    public class CartTableComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public CartTableComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CartTableViewModel vm = new CartTableViewModel() { Blends = _userService.GetCurrentUser().Blends };
            return View(vm);
        }
    }
}
