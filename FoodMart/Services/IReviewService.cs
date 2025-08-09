using FoodMart.Models;

namespace FoodMart.Services
{ 
    public interface IReviewService
    {

        void AddReview(Review review, IFormFile ImageFile);
        List<Review> GetReviews();



    }
}
