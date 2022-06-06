using BookReviewer.Api.Data;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Api.Repositories;

public class BookRepository : IBookRepository
{
    private readonly DataContext _context;
    public BookRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Book>> GetBooksAsync() => await _context.Book.ToListAsync();

    public async Task<Book?> GetBookAsync(int id) => await _context.Book.FirstOrDefaultAsync(b => b.Id == id);

    public async Task<bool> BookExistsAsync(int id) => await _context.Book.AnyAsync(b => b.Id == id);
    
    public IEnumerable<AuthorBook> GetBooks(int authorId)
    {
        var books = _context.AuthorBook.Where(ab => ab.AuthorId == authorId)
            .Include(ab => ab.Book)
            .AsEnumerable();
        return books;
    }

    public async Task<Book?> GetBookAsync(string title)
    {
        return await _context.Book.FirstOrDefaultAsync(b =>
            b.Title.ToUpper() == title.ToUpper());
    }

    public async Task<double> GetBookRatingAsync(int id)
    {
        var ratings = await _context.Review.Where(r => r.Book.Id == id).ToListAsync();
        if (!ratings.Any())
            return 0;
        var ovrRating = (double)ratings.Sum(r => r.Rating) / ratings.Count();
        return Math.Round(ovrRating, 1);
    }

}