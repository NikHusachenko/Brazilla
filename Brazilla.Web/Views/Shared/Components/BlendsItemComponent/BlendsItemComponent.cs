using Brazilla.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Views.Shared.Components.BlendsItemComponent
{
    public class BlendsItemComponent : ViewComponent
    {
        private readonly ICurrentUser _currentUser;

        public BlendsItemComponent(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public async Task<IViewComponentResult> InvokeAsync(BlendsItemViewModel vm)
        {
            vm.buyerId = _currentUser.Id;
            return View(vm);
        }
    }
}
