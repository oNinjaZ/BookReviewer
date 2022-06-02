namespace BookReviewer.Api.Models;

public class Reviewer 
{
    public int Id { get; set; }
    public string Username { get; set; } = default!;
    public ICollection<Review> Reviews { get; set; } = default!;
}