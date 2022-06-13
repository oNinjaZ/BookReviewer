namespace BookReviewer.Api.Dtos;
public class AuthorCreateDto
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
}