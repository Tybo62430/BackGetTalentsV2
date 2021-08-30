using BackGetTalentsV2.Business;
using BackGetTalentsV2.Business.Review;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private gettalentsContext _dbContext;

        public ReviewRepository(gettalentsContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Create(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
        }

        public Review GetReviewById(int id)
        {
            Review review = _dbContext.Reviews
                .Where(a => a.Id.Equals(id))
                .Include(a => a.Pictures)
                .Include(a => a.Commentator)
                .ThenInclude(u => u.Picture)
                .Include(a => a.User)
                .ThenInclude(u => u.Picture)
                .FirstOrDefault();

            if (review == null)
            {
                throw new ReviewNotFoundException();
            }

            return review;
        }

        public IList<Review> GetAllReviews()
        {
            return _dbContext.Reviews
                .Include(a => a.Pictures)
                .Include(a => a.Commentator)
                .ThenInclude(u => u.Picture)
                .Include(a => a.User)
                .ThenInclude(u => u.Picture)
                .ToList();
        }

        public IList<Review> GetReceivedReviews(int userId)
        {
            return _dbContext.Reviews
                .Where(a => a.UserId.Equals(userId))
                .Include(a => a.Pictures)
                .Include(a => a.Commentator)
                .ThenInclude(u => u.Picture)
                .Include(a => a.User)
                .ThenInclude(u => u.Picture)
                .ToList();
        }

        public IList<Review> GetPostedReviews(int userId)
        {
            return _dbContext.Reviews
                .Where(a => a.Commentator.Equals(userId))
                .Include(a => a.Pictures)
                .Include(a => a.Commentator)
                .ThenInclude(u => u.Picture)
                .Include(a => a.User)
                .ThenInclude(u => u.Picture)
                .ToList();
        }

        public void Update(Review review)
        {
            Review reviewTemp = _dbContext.Reviews.Where(c => c.Id.Equals(review.Id)).FirstOrDefault();

            if (reviewTemp == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            if (reviewTemp != null)
            {
                reviewTemp.Title = review.Title;
                reviewTemp.Comment = review.Comment;
                reviewTemp.Note = review.Note;
                reviewTemp.CreatedAt = review.CreatedAt;
                reviewTemp.UpdatedAt = review.UpdatedAt;
                reviewTemp.Pictures = review.Pictures;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            if (GetReviewById(review.Id) != null)
            {
                _dbContext.Reviews.Remove(review);
                _dbContext.SaveChanges();
            }
        }
    }
}