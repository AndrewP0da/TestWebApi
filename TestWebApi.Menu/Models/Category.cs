using System.Text.Json.Serialization;

namespace TestWebApi.Menu.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }

        public string? Name { get; set; }

        public List<MenuItemResponse>? MenuItems { get; set; }
    }
}
