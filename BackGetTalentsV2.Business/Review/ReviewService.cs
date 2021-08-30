using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Review
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void AddReview(Review review)
        {
            _reviewRepository.Create(review);
        }

        public void DeleteReview(int id)
        {
            Review review = _reviewRepository.GetReviewById(id);

            if (review == null)
            {
                throw new ReviewNotFoundException();
            }

            _reviewRepository.Delete(review);
        }

        public Review GetReviewById(int id)
        {
            Review review = _reviewRepository.GetReviewById(id);

            if (review == null)
            {
                throw new ReviewNotFoundException();
            }

            return review;
        }

        public IList<Review> GetAllReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public IList<Review> GetReceivedReviews(int userId)
        {
            return _reviewRepository.GetReceivedReviews(userId);
        }

        public IList<Review> GetPostedReviews(int userId)
        {
            return _reviewRepository.GetPostedReviews(userId);
        }

        public void UpdateReview(int id, Review review)
        {
            Review tempReview = _reviewRepository.GetReviewById(id);

            if (tempReview == null)
            {
                throw new ReviewNotFoundException();
            }

            _reviewRepository.Update(review);
        }
    }
}