using BookReviewer.Api.Dtos;
using BookReviewer.Api.Models;

namespace BookReviewer.Api.Interfaces;

public interface IAuthorBookRepository 
{
    Task<bool> AddAuthorToBookAsync(AuthorBookDto dto);
    Task<bool> CheckExistsAsync(int authorId, int bookId);
    Task<bool> DeleteAuthorBookAsync(int authorId, int bookId);
    Task<AuthorBook?> GetByIdsAsync(int authorId, int bookId);
}