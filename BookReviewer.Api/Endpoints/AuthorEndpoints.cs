using BookReviewer.Api.Dtos.Author;
using BookReviewer.Api.Extensions;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Models;
using BookReviewer.Api.Repositories;

namespace BookReviewer.Api.Endpoints;

public static class AuthorEndpoints
{
    public static IServiceCollection AddAuthorEndpoints(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        return services;
    }

    public static void UseAuthorEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/authors", async (AuthorCreateDto dto, IAuthorRepository authorRepo) =>
        {
            var created = await authorRepo.CreateAuthorAsync(new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            });
        });

        app.MapGet("/authors", async (IAuthorRepository authorRepo) =>
        {
            var authors = await authorRepo.GetAuthorsAsync();
            return Results.Ok(authors);
        });

        app.MapGet("/authors/{id}", async (int id, IAuthorRepository authorRepo) =>
        {
            var author = await authorRepo.GetAuthorAsync(id);
            if (author is null)
                return Results.NotFound();

            return Results.Ok(author.AsDto());
        });

        app.MapDelete("/authors/{id}", async (int id, IAuthorRepository authorRepo) =>
        {
            return await authorRepo.DeleteAuthorAsync(id)
                ? Results.Ok()
                : Results.NotFound();
        });
    }
}