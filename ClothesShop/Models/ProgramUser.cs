using ClothesShop.Migrations;
using Microsoft.AspNetCore.Identity;

namespace ClothesShop.Models
{
    public class ProgramUser:IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
