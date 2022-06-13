using System.Text.Json.Serialization;

namespace BookReviewer.Api.Models;

public class Review 
{
    public int Id { get; set; } = default!; 
    public string Text { get; set; } = default!;
    public int? Rating { get; set; }


    // navigation props

    [JsonIgnore]
    public Book Book { get; set; } = default!;

    [JsonIgnore]
    public User User { get; set; } = default!;
}