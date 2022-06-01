using BookReviewer.Api.Data;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Api.Repository;

public class BookRepository : IBookRepository
{
    private readonly DataContext _context;
    public BookRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Book>> GetBooksAsync()
    {
        return await _context.Book!.OrderBy(b => b.Id).ToListAsync();
    }
}