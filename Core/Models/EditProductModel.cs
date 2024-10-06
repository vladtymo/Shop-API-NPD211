using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class EditProductModel
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(200), MinLength(3)]
        public string Name { get; set; } = null!;

        [Url]
        public string? ImageUrl { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
    }
}
