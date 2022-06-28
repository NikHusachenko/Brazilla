using Brazilla.Services.BlendTypeServices;
using Brazilla.Services.BlendTypeServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brazilla.Web.Controllers
{
    [Authorize]
    public class BlendTypesController : Controller
    {
        private readonly IBlendTypeService _blendTypeService;

        public BlendTypesController(IBlendTypeService blendTypeService)
        {
            _blendTypeService = blendTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Settings([FromBody]SettingsViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { responseMessage = "Invlida data" });
            }

            if(!_blendTypeService.Create(vm))
            {
                return BadRequest(new { responseMessage = "Was created" });
            }

            return Ok(new { responseMessage = Url.Action("Settings", "BlendTypes") });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            _blendTypeService.Delete(id);
            return RedirectToAction("Settings", "BlendTypes");
        }
    }
}