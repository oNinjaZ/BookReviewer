using BookReviewer.Api.Models;

namespace BookReviewer.Api.Interfaces;

public interface IAuthorRepository
{
    Task<bool> CreateAuthorAsync(Author author);
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author?> GetAuthorAsync(int id);
    Task<bool> UpdateAuthorAsync(Author author);
    Task<bool> DeleteAuthorAsync(int id);
    Task<bool> AuthorExistsAsync(int id);
    
}