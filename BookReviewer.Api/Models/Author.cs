using System.Text.Json.Serialization;

namespace BookReviewer.Api.Models;

public class Author 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }


    // navigation props

    [JsonIgnore]
    public ICollection<AuthorBook> AuthorBooks { get; set; } = default!;
}