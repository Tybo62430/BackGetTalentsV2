using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Review
{
    public interface IReviewRepository
    {
        void Create(Review review);
        IList<Review> GetAllReviews();
        Review GetReviewById(int id);
        IList<Review> GetReceivedReviews(int userId);
        IList<Review> GetPostedReviews(int userId);
        void Update(Review review);
        void Delete(Review review);
    }
}