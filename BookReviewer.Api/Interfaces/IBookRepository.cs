using BookReviewer.Api.Models;

namespace BookReviewer.Api.Interfaces;

public interface IBookRepository
{
    public Task<ICollection<Book>> GetBooksAsync();
}