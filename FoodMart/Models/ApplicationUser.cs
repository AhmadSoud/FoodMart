using Microsoft.AspNetCore.Identity;

namespace FoodMart.Models
{
    public class ApplicationUser: IdentityUser
    {
        public int Age { get; set; }
    }
}
