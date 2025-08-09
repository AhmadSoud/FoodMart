using FoodMart.Models;
using FoodMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMart.Controllers
{
    public class ReviewController : Controller
    {


        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create(Review review, IFormFile ImageFile  )
        {
            _reviewService.AddReview(review , ImageFile);
            return RedirectToAction("Index");

        }

        public IActionResult GetReviews()
        {
            var reviews = _reviewService.GetReviews();
            return View("GetReviews",reviews);

        }
    }
}
