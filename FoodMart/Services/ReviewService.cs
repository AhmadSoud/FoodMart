using FoodMart.Data;
using FoodMart.Models;

namespace FoodMart.Services
{
    public class ReviewService : IReviewService
    {
        private readonly FoodMartContext _Context;
        public ReviewService(FoodMartContext context)
        {
            _Context = context;
        }
        public void AddReview(Review review, IFormFile ImageFile)
        {

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                ImageFile.CopyTo(stream);
            }

            review.ImagePath = "/images/" + uniqueFileName;

            _Context.Reviews.Add(review);
            _Context.SaveChanges();
        }

        public List<Review> GetReviews()
        {
            return _Context.Reviews.ToList();

        }




    }
}
