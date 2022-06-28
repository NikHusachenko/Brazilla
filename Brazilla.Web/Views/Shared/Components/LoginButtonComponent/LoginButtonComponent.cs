using Brazilla.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Views.Shared.Components.LoginButton
{
    public class LoginButtonComponent : ViewComponent
    {
        private readonly ICurrentUser _currentUser;

        public LoginButtonComponent(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            LoginButtonViewModel vm = new LoginButtonViewModel() { IsLoginder = _currentUser.IsAuthenticated };
            return View(vm);
        }
    }
}
