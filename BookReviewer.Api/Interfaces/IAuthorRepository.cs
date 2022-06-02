using BookReviewer.Api.Models;

namespace BookReviewer.Api.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author?> GetAuthorAsync(int id);
    Task<Author?> GetAuthorAsync(string first);
    Task<bool> CreateAuthorAsync(Author author);
    Task<bool> DeleteAuthorAsync(int id);
    Task<bool> AuthorExistsAsync(int id);
    
}