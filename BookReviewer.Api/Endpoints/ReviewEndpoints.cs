using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Repositories;

namespace BookReviewer.Api.Endpoints;

public static class ReviewEndpoints
{
    public static IServiceCollection AddReviewEndpoints(this IServiceCollection services)
    {
        services.AddScoped<IReviewRepository, ReviewRepository>();
        return services;
    }

    public static void UseReviewEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/reviews", async (IReviewRepository reviewRepo) =>
        {
            var reviews = await reviewRepo.GetReviewsAsync();
            return Results.Ok(reviews);
        });

        app.MapGet("/reviews/{id}", async (int id, IReviewRepository reviewRepo) =>
        {
            var review = await reviewRepo.GetReviewAsync(id);
            if (review is null)
                return Results.NotFound();

            return Results.Ok(review);
        });
    }
}