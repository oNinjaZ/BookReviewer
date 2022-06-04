namespace BookReviewer.Api.Models;

public class AuthorBook
{
    public int AuthorId { get; set; }
    public int BookId { get; set; }
    public Author Author { get; set; } = default!;
    public Book Book { get; set; } = default!;
}