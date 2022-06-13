using BookReviewer.Api.Dtos;
using BookReviewer.Api.Models;

namespace BookReviewer.Api.Extensions;

public static class UserMappingExtensions
{
    public static UserReadDto AsDto(this User user)
    {
        return new UserReadDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email
        };
    }
}