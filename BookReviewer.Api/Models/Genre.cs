namespace BookReviewer.Api.Models;

public class Genre 
{
    public int Id { get; set; } 
    public string Name { get; set; } = default!;
    public ICollection<BookGenre> BookGenres { get; set; } = default!;
}