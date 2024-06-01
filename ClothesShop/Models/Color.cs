using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }
        [ValidateNever]
        public bool IsActive { get; set; }
        public List<ColorToProduct> ColorToProducts { get; set; }
    }
}
