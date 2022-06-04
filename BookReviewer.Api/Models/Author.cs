namespace BookReviewer.Api.Models;

public class Author 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public ICollection<AuthorBook> AuthorBooks { get; set; } = default!;
}