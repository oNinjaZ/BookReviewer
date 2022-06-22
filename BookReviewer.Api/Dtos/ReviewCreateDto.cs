namespace BookReviewer.Api.Dtos;

public class ReviewCreateDto
{
    public int Id { get; set; } = default!;
    public string Text { get; set; } = default!;
    public int? Rating { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
}