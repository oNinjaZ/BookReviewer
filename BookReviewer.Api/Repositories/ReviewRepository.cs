using BookReviewer.Api.Data;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Api.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly DataContext _context;

    public ReviewRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateReviewAsync(Review review)
    {
        await _context.Review.AddAsync(review);
        return await SaveAsync();
    }

    public async Task<IEnumerable<Review>> GetReviewsAsync()
    {
        return await _context.Review
            .Include(r => r.Book)
            .Include(r => r.User)
            .ToListAsync();
    }

    public async Task<Review?> GetReviewAsync(int id)
    {
        return await _context.Review
            .Include(r => r.Book)
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Id == id);

    }

    public async Task<bool> UpdateReviewAsync(Review review)
    {
        _context.Update(review);
        return await SaveAsync();
    }

    public async Task<bool> DeleteReviewAsync(int id)
    {
        var review = await GetReviewAsync(id);
        if (review is null)
            return false;

        _context.Review.Remove(review);
        return await SaveAsync();
    }

    public async Task<bool> ReviewExistsAsync(int id) => await _context.Review.AnyAsync(r => r.Id == id);

    public async Task<bool> SaveAsync()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}