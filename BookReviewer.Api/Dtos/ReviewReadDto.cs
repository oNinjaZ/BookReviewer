using BookReviewer.Api.Models;

namespace BookReviewer.Api.Dtos;

public class ReviewReadDto
{
    public int Id { get; set; } = default!;
    public string Text { get; set; } = default!;
    public int? Rating { get; set; }

    // navigation props
    // public Book Book { get; set; } = default!;

    // public UserReadDto User { get; set; } = default!;
    public int BookId { get; set; } = default!;

    public int UserId { get; set; } = default!;
}