namespace BookReviewer.Api.Dtos;

public class AuthorUpdateDto
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
}