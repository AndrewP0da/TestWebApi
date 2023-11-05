using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Controllers;
using TestWebApi.Menu;
using TestWebApi.Menu.Models;

namespace TestWebApi.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMenuItemService _menuItemService;

        public CategoryController(ICategoryService categoryService, IMenuItemService menuItemService)
        {
            _categoryService = categoryService;
            _menuItemService = menuItemService;
        }

        [Route("Get[controller]")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryService.Get(id);
            var menuItems = await _menuItemService.GetAll();

            if (category != null)
            {
                if (menuItems != null)
                {
                    category.MenuItems = new List<MenuItemResponse>();

                    foreach (var menuItem in menuItems)
                    {
                        if (menuItem.CategoryId == category.CategoryId)
                        {
                            category.MenuItems.Add(menuItem);
                        }
                    }
                }
            }

            return Ok(category);
        }

        [Route("GetAll[controller]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listCategory = await _categoryService.GetAll();
            if (listCategory == null)
                return Conflict("Відсутні дані категорій меню");

            var menuItems = await _menuItemService.GetAll();

            if (menuItems != null)
            {
                foreach (var category in listCategory)
                {
                    category.MenuItems = new List<MenuItemResponse>();

                    foreach (var menuItem in menuItems)
                    {
                        if (menuItem.CategoryId == category.CategoryId)
                        {
                            category.MenuItems.Add(menuItem);
                        }
                    }
                }
            }

            return Ok(listCategory);
        }

        [Route("Create[controller]")]
        [HttpPost]
        public async Task<IActionResult> Create(string nameCategory)
        {
            var resultExist = await _categoryService.CategoryExists(nameCategory);

            if (resultExist == true)
                return Conflict("Категорія з такою назвою вже існує");

            Category category = new()
            {
                Name = nameCategory
            };

            var categoryId = await _categoryService.Create(category);

            return Ok(categoryId);
        }

        [Route("Update[controller]")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid categoryId, string newName)
        {
            var result = await _categoryService.Update(categoryId, newName);

            if (result == true)
            {
                return Ok();
            }
            else
            {
                return Conflict("Невдалось оновити запис. Перевірте правильність CategoryId");
            }
        }

        [Route("Delete[controller]")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Delete(id);

            return Ok();
        }
    }
}
