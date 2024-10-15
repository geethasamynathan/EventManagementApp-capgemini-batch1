using EventManagement_Backend.Models;

namespace EventManagement_Backend.IRepository
{
    public interface IReview
    {
        string AddReview(Review review);
        string DeleteReview(int reviewId);
        string UpdateReview(Review review);
        List<Review> GetAllReviews();
        Review GetReviewsByEventId(int eventId);
    }
}
