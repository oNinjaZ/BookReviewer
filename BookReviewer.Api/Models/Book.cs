namespace BookReviewer.Api.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public DateTime PublishDate { get; set; }
    public int PageCount { get; set; }
    public Author Author { get; set; } = default!;
    public ICollection<Review> Reviews { get; set; } = default!;
    public ICollection<BookGenre> BookGenres { get; set; } = default!;
    public ICollection<BookTag> BookTags { get; set; } = default!;
}