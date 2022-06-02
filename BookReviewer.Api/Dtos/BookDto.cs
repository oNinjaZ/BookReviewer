namespace BookReviewer.Api.Dtos;

public record BookDto
{
    public int Id { get; init; }
    public string Title { get; init; } = default!;
    public DateTime PublishDate { get; set; }
    public int PageCount { get; init; }
}