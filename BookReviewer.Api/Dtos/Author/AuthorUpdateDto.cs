namespace BookReviewer.Api.Dtos.Author;

public class AuthorUpdateDto
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
}