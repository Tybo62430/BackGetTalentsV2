using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Review
{
    public interface IReviewService
    {
        void AddReview(Review review);
        IList<Review> GetAllReviews();
        Review GetReviewById(int id);
        IList<Review> GetReceivedReviews(int userId);
        IList<Review> GetPostedReviews(int userId);
        void UpdateReview(int id, Review review);
        void DeleteReview(int id);
    }
}