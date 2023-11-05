namespace TestWebApi.DB.Entities
{
    public class MenuItemEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Composed { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public string? Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public string? Description { get; set; }
    }
}
