namespace BookReviewer.Api.Models;

public class Genre 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<BookGenre>? BookGenres { get; set; }
}