namespace BookReviewer.Api.Dtos.Author;

public class AuthorReadDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}