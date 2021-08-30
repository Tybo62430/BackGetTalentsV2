using BackGetTalentsV2.Business.Review;
using BackGetTalentsV2.Business.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Controllers
{
    [Route("reviews")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public IActionResult CreateReview([FromBody] ReviewDTOMinimalist reviewDTO)
        {
            Review review = ReviewHelper.ConvertReviewDTO(reviewDTO);

            _reviewService.AddReview(review);

            return Created(nameof(CreateReview), review);
        }

        [HttpGet]
        public IActionResult GetReviews()
        {
            IList<Review> reviews = _reviewService.GetAllReviews();

            List<ReviewDTO> reviewsDTO = ReviewHelper.ConvertReviews(reviews.ToList());

            return Ok(reviewsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetReviewById([FromRoute] int id)
        {
            try
            {
                Review review = _reviewService.GetReviewById(id);

                ReviewDTO reviewDTO = ReviewHelper.ConvertReview(review);

                return Ok(reviewDTO);
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("received/{userId}")]
        public IActionResult GetReceivedReviews([FromRoute] int userId)
        {
            IList<Review> reviews = _reviewService.GetReceivedReviews(userId);

            List<ReviewDTO> reviewsDTO = ReviewHelper.ConvertReviews(reviews.ToList());

            return Ok(reviewsDTO);
        }

        [HttpGet]
        [Route("posted/{userId}")]
        public IActionResult GetPostedReviews([FromRoute] int userId)
        {
            IList<Review> reviews = _reviewService.GetPostedReviews(userId);

            List<ReviewDTO> reviewsDTO = ReviewHelper.ConvertReviews(reviews.ToList());

            return Ok(reviewsDTO);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteReview([FromRoute] int id)
        {
            try
            {
                _reviewService.DeleteReview(id);

                return NoContent();
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateReview([FromRoute] int id, [FromBody] ReviewDTOMinimalist reviewDTO)
        {
            try
            {
                Review review = ReviewHelper.ConvertReviewDTO(reviewDTO);

                _reviewService.UpdateReview(id, review);

                return NoContent();
            }
            catch (ReviewNotFoundException)
            {
                return NotFound();
            }
        }
    }
}