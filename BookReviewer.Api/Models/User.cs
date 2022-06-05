namespace BookReviewer.Api.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;
    public ICollection<Review> Reviews { get; set; } = default!;
}
