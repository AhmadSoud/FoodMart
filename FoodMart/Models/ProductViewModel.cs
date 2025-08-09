using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodMart.Models
{
    public class ProductViewModel
    {
       public Product product { get; set; }
        public List<SelectListItem>? categories {  get; set; } 
    }
}
