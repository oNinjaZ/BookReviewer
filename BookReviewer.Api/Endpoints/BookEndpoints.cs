using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Repository;

namespace BookReviewer.Api.Endpoints;

public static class BookEndpoints
{
    public static IServiceCollection AddBookEndpoints(this IServiceCollection services)
    {
        services.AddTransient<IBookRepository, BookRepository>();
        return services;
    }

    public static IEndpointRouteBuilder UseBookEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/books", async (IBookRepository bookRepo) =>
        {
            var books = await bookRepo.GetBooksAsync();
            return Results.Ok(books);
        });
        
        return app;
    }
}