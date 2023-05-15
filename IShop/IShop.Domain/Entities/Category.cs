using System.ComponentModel.DataAnnotations;

namespace IShop.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Range(0, int.MaxValue)]
        public int DisplayOrder { get; set; }
    }
}
