namespace BookReviewer.Api.Models;

public class BookGenre 
{
    public int BookId { get; set; }
    public int GenreId { get; set; }
    public Book Book { get; set; } = default!;
    public Genre Genre { get; set; } = default!;
}