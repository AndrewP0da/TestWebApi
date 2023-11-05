using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Controllers;
using TestWebApi.Menu;
using TestWebApi.Menu.Models;
using TestWebApi.Menu.Services;

namespace TestWebApi.Controllers
{
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [Route("Get[controller]")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var lead = await _menuItemService.Get(id);

            return Ok(lead);
        }

        [Route("GetAll[controller]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lead = await _menuItemService.GetAll();

            return Ok(lead);
        }

        [Route("Create[controller]")]
        [HttpPost]
        public async Task<IActionResult> Create(MenuItem menuItem)
        {
            var leadId = await _menuItemService.Create(menuItem);

            return Ok(leadId);
        }

        [Route("Update[controller]")]
        [HttpPut]
        public async Task<IActionResult> Update(MenuItem menuItem)
        {
            await _menuItemService.Update(menuItem);

            return Ok();
        }

        [Route("Delete[controller]")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _menuItemService.Delete(id);

            return Ok();
        }
    }
}
