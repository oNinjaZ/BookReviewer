using BookReviewer.Api.Data;
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
        return await _context.SaveChangesAsync() > 0;
        
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync() => await _context.Author.ToListAsync();

    public async Task<Author?> GetAuthorAsync(int id) => await _context.Author.FirstOrDefaultAsync(a => a.Id == id);

    public Task<bool> UpdateAuthorAsync(Author author)
    {
        throw new NotImplementedException(); // todo
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        var author = await GetAuthorAsync(id);
        if (author is null)
            return false;

        _context.Author.Remove(author);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<bool> AuthorExistsAsync(int id) => await _context.Author.AnyAsync(a => a.Id == id);
}