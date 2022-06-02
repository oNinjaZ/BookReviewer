namespace BookReviewer.Api.Models;

public class BookTag 
{
    public int BookId { get; set; }
    public int TagId { get; set; }
    public Book Book { get; set; } = default!;
    public Tag Tag { get; set; } = default!;
}