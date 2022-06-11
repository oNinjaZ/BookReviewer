using BookReviewer.Api.Models;

namespace BookReviewer.Api.Interfaces;

public interface IBookRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    Task<bool> CreateBookAsync(Book book);

    /// <summary>
    /// Gets all Books.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Book>> GetBooksAsync();

    /// <summary>
    /// Gets Book by id.
    /// </summary>
    /// <param name="id"></param>
    /// /// <returns> The Book if found; otherwise, null.</returns>
    Task<Book?> GetBookAsync(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    Task<bool> UpdateBookAsync(Book book);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteBookAsync(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> BookExistsAsync(int id);
}