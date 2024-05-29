using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Models
{
    public class Order
    {


        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string Shipping { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public ProgramUser Users { get; set; }

        public List<OrderItem> OrderItems { get; set; }


        ////////public int Id { get; set; }
        //////// public int ProductId { get; set; }
        //////// public int UserId { get; set; }
        //////// [ForeignKey("ProductId")]
        //////// public Products Products { get; set; }
        //////// [ForeignKey("UserId")]
        //////// public ProgramUser Users { get; set; }
        //////// public int Count { get; set; }

    }
}
