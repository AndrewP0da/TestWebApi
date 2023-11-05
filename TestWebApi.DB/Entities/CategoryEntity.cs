using System.ComponentModel.DataAnnotations;

namespace TestWebApi.DB.Entities
{
    public class CategoryEntity : BaseEntity
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        //public List<MenuItem>? MenuItems { get; set; }
    }
}
