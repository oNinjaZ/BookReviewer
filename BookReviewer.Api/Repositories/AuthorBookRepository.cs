using BookReviewer.Api.Data;
using BookReviewer.Api.Dtos;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Api.Repositories;

public class AuthorBookRepository : IAuthorBookRepository
{
    private readonly DataContext _context;

    public AuthorBookRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAuthorToBookAsync(AuthorBookDto dto)
    {
        await _context.AuthorBook.AddAsync(new AuthorBook
        {
            AuthorId = dto.AuthorId,
            BookId = dto.BookId
        });

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> CheckExistsAsync(int authorId, int bookId)
    {
        return await _context.AuthorBook.AnyAsync(
            ab => ab.AuthorId == authorId && ab.BookId == bookId);
    }

    public async Task<bool> DeleteAuthorBookAsync(int authorId, int bookId)
    {
        var existingAuthorBook = await GetByIdsAsync(authorId, bookId);
        if (existingAuthorBook is null)
            return false;

        _context.Remove(existingAuthorBook);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<AuthorBook?> GetByIdsAsync(int authorId, int bookId)
    {
        return await _context.AuthorBook.FirstOrDefaultAsync(
            ab => ab.AuthorId == authorId && ab.BookId == bookId);
    }
}