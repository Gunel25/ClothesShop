using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public int  ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
    }
}
