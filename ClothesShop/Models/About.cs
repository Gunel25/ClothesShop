using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClothesShop.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Story { get; set; }
        [Required]
        public string Mission { get; set; }
        [Required]
        public string Vision { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }

    }
}
