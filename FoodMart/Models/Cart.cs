using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMart.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public int Quantity { get; set; }  // New attribute: number of items in the cart

        [ForeignKey("product")]
        public int ProductID { get; set; }
        public Product? Product { get; set; }

    }
}
