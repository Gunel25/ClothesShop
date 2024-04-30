using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        [ForeignKey("UserId")]
        public User Users { get; set; }
    }
}
