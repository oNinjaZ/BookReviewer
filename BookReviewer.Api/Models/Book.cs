namespace BookReviewer.Api.Models;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Type { get; set; }
    public DateTime PublishDate { get; set; }
    public int PageCount { get; set; }
}