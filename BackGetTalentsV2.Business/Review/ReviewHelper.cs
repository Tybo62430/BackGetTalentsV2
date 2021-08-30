using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Review
{
    public class ReviewHelper
    {
        public static List<ReviewDTO> ConvertReviews(List<Review> reviews)
        {
            return reviews.ConvertAll(review => ConvertReview(review));
        }

        public static ReviewDTO ConvertReview(Review review)
        {
            ReviewDTO reviewDTO = new()
            {
                Id = review.Id,
                Title = review.Title,
                Comment = review.Comment,
                Note = review.Note,
                CreatedAt = review.CreatedAt,
                UpdatedAt = review.UpdatedAt,
                Pictures = Picture.PictureHelper.ConvertPictures(review.Pictures.ToList()),
                Sender = User.UserHelper.ConvertUserMinimalist(review.Commentator),
                Recipient = User.UserHelper.ConvertUserMinimalist(review.User)
            };

            return reviewDTO;
        }

        public static Review ConvertReviewDTO(ReviewDTOMinimalist reviewDTO)
        {
            Review review = new()
            {
                Id = reviewDTO.Id,
                Title = reviewDTO.Title,
                Comment = reviewDTO.Comment,
                Note = reviewDTO.Note,
                CreatedAt = reviewDTO.CreatedAt,
                UpdatedAt = reviewDTO.UpdatedAt,
                Pictures = Picture.PictureHelper.ConvertPicturesDTO(reviewDTO.Pictures.ToList()),
            };

            return review;
        }
    }
}
