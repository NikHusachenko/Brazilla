using Brazilla.Database.Entities;
using Brazilla.Services.UserServices;
using Brazilla.Services.UserServices.Models;
using Brazilla.Web.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> SignUpAsync([FromBody]SignUpViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { errorMessage = "Invalid data" });
            }

            if(!_userService.Create(vm))
            {
                return BadRequest(new { errorMessage = "Was created" });
            }

            return Ok(new { redirectUrl = Url.Action("SignIn", "User") });
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult SignIn([FromBody]SignInViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest( new { errorMessage = "Entered incorrect data" });
            }

            if(_userService.GetByLoginAndPassword(vm.Login, vm.Password) == null)
            {
                return BadRequest(new { errorMessage = "Account not found"});
            }

            _userService.SignIn(vm.Login, vm.Password);
            return Ok(new { redirectUrl = Url.Action("Index", "Home") });
        }

        [Authorize]
        [HttpGet]
        public IActionResult SignOut()
        {
            _userService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Buy(long id)
        {
            _userService.Buy(id);
            var user = _userService.GetCurrentUser();
            return RedirectToAction("Cart", "User");
        }
    }
}