namespace BookReviewer.Api.Models;

public class Review 
{
    public int Id { get; set; } = default!; 
    public string Text { get; set; } = default!;
    public int Rating { get; set; }
    public Book Book { get; set; } = default!;
    public User User { get; set; } = default!;
}