using TestWebApi.Menu.Models;

namespace TestWebApi.Menu
{
    public interface IMenuItemService
    {
        Task<Guid> Create(MenuItem menuItem);
        Task<MenuItem> Get(Guid id);
        Task<List<MenuItem>> GetAll();
        Task Update(MenuItem menuItem);
        Task Delete(Guid itemId);
    }
}
