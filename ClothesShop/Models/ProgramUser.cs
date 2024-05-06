using ClothesShop.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClothesShop.Models
{
    public class ProgramUser:IdentityUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [ValidateNever]
        public List<Orders> Orders { get; set; }
    }
}
