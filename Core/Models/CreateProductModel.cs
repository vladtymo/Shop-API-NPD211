using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
