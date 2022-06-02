namespace BookReviewer.Api.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public DateTime PublishDate { get; set; }
    public int PageCount { get; set; }
}