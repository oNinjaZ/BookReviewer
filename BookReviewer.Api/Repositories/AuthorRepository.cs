using BookReviewer.Api.Data;
using BookReviewer.Api.Dtos;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Api.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly DataContext _context;

    public AuthorRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAuthorAsync(Author author)
    {
        await _context.Author.AddAsync(author);
        return await SaveAsync();
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await _context.Author
            .Include(a => a.AuthorBooks)
            .ThenInclude(ab => ab.Book)
            .ToListAsync();

    }

    public async Task<Author?> GetAuthorAsync(int id)
    {
        return await _context.Author
            .Include(a => a.AuthorBooks)
            .ThenInclude(ab => ab.Book)
            .FirstAsync(author => author.Id == id);
    }

    public async Task<bool> UpdateAuthorAsync(Author author)
    {
        _context.Update(author);
        return await SaveAsync();
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        var author = await GetAuthorAsync(id);
        if (author is null)
            return false;

        _context.Author.Remove(author);
        return await SaveAsync();
    }


    public async Task<bool> AuthorExistsAsync(int id) => await _context.Author.AnyAsync(a => a.Id == id);

    public async Task<bool> SaveAsync()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}