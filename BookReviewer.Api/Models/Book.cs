namespace BookReviewer.Api.Models;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime PublishDate { get; set; }
    public int PageCount { get; set; }
    public Author? Author { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<BookGenre>? BookGenres { get; set; }
    public ICollection<BookTag>? BookTags { get; set; }
}