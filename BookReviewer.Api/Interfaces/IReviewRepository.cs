using BookReviewer.Api.Models;

namespace BookReviewer.Api.Interfaces;

public interface IReviewRepository
{
    Task<bool> CreateReviewAsync(Review review);
    Task<IEnumerable<Review>> GetReviewsAsync();
    Task<Review?> GetReviewAsync(int id);
    Task<bool> UpdateReviewAsync(Review review);
    Task<bool> DeleteReviewAsync(int id);
    Task<bool> ReviewExistsAsync(int id);
    Task<bool> SaveAsync();
}