using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    public class ColorToProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        [ForeignKey("ColorId")]

        public Color Color { get; set; }
    }
}
