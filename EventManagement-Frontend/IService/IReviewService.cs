using EventManagement_Backend.Models;
using EventManagement_Frontend.Models;

namespace EventManagement_Frontend.IService
{
    public interface IReviewService
    {
        //Task<List<ReviewModel>> GetAllReviews(int eventId); // Get reviews by EventId
        //Task<bool> RemoveReview(int reviewId); // Delete a review by its ReviewId
       
            Task<List<ReviewModel>> GetAllReviews();
        

    }
}
