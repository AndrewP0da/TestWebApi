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
            var menuItem = await _menuItemService.Get(id);

            return Ok(menuItem);
        }

        [Route("GetAll[controller]s")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menuItem = await _menuItemService.GetAll();

            return Ok(menuItem);
        }

        [Route("Create[controller]")]
        [HttpPost]
        public async Task<IActionResult> Create(MenuItem menuItem)
        {
            var menuItemId = await _menuItemService.Create(menuItem);

            return Ok(menuItemId);
        }

        [Route("Update[controller]")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid idMenuItem, MenuItem menuItem)
        {
            await _menuItemService.Update(idMenuItem, menuItem);

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
