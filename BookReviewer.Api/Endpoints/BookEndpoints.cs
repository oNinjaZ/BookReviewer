using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Repository;

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

            return Results.Ok(books);
        });
    }
}