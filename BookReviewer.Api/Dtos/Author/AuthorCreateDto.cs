namespace BookReviewer.Api.Dtos.Author;
public class AuthorCreateDto 
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
}