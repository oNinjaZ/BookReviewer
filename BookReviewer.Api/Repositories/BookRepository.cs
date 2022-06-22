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

    public async Task<bool> CreateBookAsync(Book book)
    {
        await _context.Book.AddAsync(book);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync() => await _context.Book.ToListAsync();

    public async Task<Book?> GetBookAsync(int id) => await _context.Book.FirstOrDefaultAsync(b => b.Id == id);


    public Task<bool> UpdateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBookAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> BookExistsAsync(int id) => await _context.Book.AnyAsync(b => b.Id == id);

    public async Task<bool> SaveAsync()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}