using TestWebApi.Menu.Models;

namespace TestWebApi.Menu
{
    public interface IMenuItemService
    {
        Task<Guid> Create(MenuItem menuItem);
        Task<MenuItemResponse> Get(Guid id);
        Task<List<MenuItemResponse>> GetAll();
        Task<bool> Update(Guid idMenuItem, MenuItem menuItem);
        Task Delete(Guid itemId);
    }
}
