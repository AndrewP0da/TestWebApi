namespace TestWebApi.DB.Entities
{
    public class MenuItemEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Composed { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
    }
}
