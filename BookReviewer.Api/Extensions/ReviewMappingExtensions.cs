using BookReviewer.Api.Dtos;
using BookReviewer.Api.Models;

namespace BookReviewer.Api.Extensions;
public static class ReviewMappingExtensions
{
    public static ReviewReadDto AsDto(this Review review)
    {
        return new ReviewReadDto
        {
            Id = review.Id,
            Text = review.Text,
            Rating = review.Rating,
            BookId = review.Book.Id,
            UserId = review.User.Id
        };
    }
}