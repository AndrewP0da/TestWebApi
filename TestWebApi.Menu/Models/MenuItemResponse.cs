using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestWebApi.Menu.Models
{
    public class MenuItemResponse
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Composed { get; set; }

        public string? Image { get; set; }

        public decimal? Price { get; set; }

        public string? Quantity { get; set; }

        public Guid CategoryId { get; set; }

        public string? Description { get; set; }
    }
}
