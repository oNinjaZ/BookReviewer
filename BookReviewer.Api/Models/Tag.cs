namespace BookReviewer.Api.Models;

public class Tag 
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<BookTag> BookTags { get; set; } = default!;
}