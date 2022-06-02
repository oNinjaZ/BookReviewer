using BookReviewer.Api.Models;

namespace BookReviewer.Api.Interfaces;

public interface IBookRepository
{
    Task<ICollection<Book>> GetBooksAsync();
    
    Task<Book?> GetBookAsync(int id);

    Task<Book?> GetBookAsync(string title);

    /// <summary>
    /// Calculates the average review rating of a Book.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The average rating, rounded to the nearest tenths.</returns>
    Task<double> GetBookRatingAsync(int id);
}