using BookReviewer.Api.Models;

namespace BookReviewer.Api.Dtos;

public class AuthorReadDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public IEnumerable<AuthorBook> Books { get; set; } = default!;

}