using Brazilla.Services.BlendServices;
using Brazilla.Services.BlendServices.Models;
using Brazilla.Services.BlendTypeServices;
using Brazilla.Web.Models.Blend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Controllers
{
    [Authorize]
    public class BlendController : Controller
    {
        private readonly IBlendService _blendService;

        public BlendController(IBlendService blendService)
        {
            _blendService = blendService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { responseMessage = "Invalida data" });
            }

            _blendService.Create(vm);

            return Ok(new { responseMessage = Url.Action("Create", "Blend") });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            _blendService.Delete(id);
            return RedirectToAction("Create", "Blend");
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            DetailsViewModel vm = new DetailsViewModel() { Blend = _blendService.GetById(id), };
            return View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Blends(long typeId = -1)
        {
            BlendsViewModel vm = new BlendsViewModel();
            if(typeId == -1)
            {
                vm.Blends = _blendService.GetAllNotBuyed();
            }
            else
            {
                vm.Blends = _blendService.GetByTypeNotBuyed(typeId);
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Buy(long blendId, long buyerId)
        {
            _blendService.Buy(blendId, buyerId);
            return RedirectToAction("Cart", "User"); // TODO
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cancel(long id)
        {
            _blendService.Cancel(id);
            return RedirectToAction("Cart", "User");
        }
    }
}
