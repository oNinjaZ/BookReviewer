using BookReviewer.Api.Models;

namespace BookReviewer.Api.Interfaces;

public interface IBookRepository
{
    /// <summary>
    /// Gets all Books.
    /// </summary>
    /// <returns></returns>
    Task<ICollection<Book>> GetBooksAsync();

    /// <summary>
    /// Gets Book by id.
    /// </summary>
    /// <param name="id"></param>
    /// /// <returns> The Book if found; otherwise, null.</returns>
    Task<Book?> GetBookAsync(int id);

    /// <summary>
    /// Gets Book by title.
    /// </summary>
    /// <param name="id"></param>
    /// <returns> The Book if found; otherwise, null.</returns>
    Task<Book?> GetBookAsync(string title);

    /// <summary>
    /// Calculates the average review rating of a Book.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The average rating, rounded to the nearest tenths.</returns>
    Task<double> GetBookRatingAsync(int id);

    
    Task<bool> BookExistsAsync(int id);
}