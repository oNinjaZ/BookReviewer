using BookReviewer.Api.Extensions;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Repositories;

namespace BookReviewer.Api.Endpoints;

public static class BookEndpoints
{
    public static IServiceCollection AddBookEndpoints(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        return services;
    }

    public static void UseBookEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/books", async (IBookRepository bookRepo) =>
        {
            var books = await bookRepo.GetBooksAsync();
            return Results.Ok(books.Select(b => b.AsDto()));
        });

        app.MapGet("/books/{id}", async (int id, IBookRepository bookRepo) =>
        {
            var book = await bookRepo.GetBookAsync(id);
            return book is not null ? Results.Ok(book.AsDto()) : Results.NotFound();
        });

        app.MapGet("/books/{id}/rating", async (int id, IBookRepository bookRepo) =>
        {
            var book = await bookRepo.GetBookAsync(id);
            if (book is null)
                return Results.NotFound();

            var rating = await bookRepo.GetBookRatingAsync(id);
            return Results.Ok(rating);
        });
    }
}