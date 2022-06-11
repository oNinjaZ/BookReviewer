using BookReviewer.Api.Dtos.Author;
using BookReviewer.Api.Models;

namespace BookReviewer.Api.Extensions;

public static class AuthorMappingExtensions
{
    public static AuthorReadDto AsDto(this Author author)
    {
        return new AuthorReadDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName
        };
    }
}