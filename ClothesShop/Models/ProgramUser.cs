using ClothesShop.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Stripe.Climate;

namespace ClothesShop.Models
{
    public class ProgramUser:IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public List<Order> Orders { get; set; }

    }
}
