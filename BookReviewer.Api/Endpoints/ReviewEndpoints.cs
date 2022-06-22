using BookReviewer.Api.Dtos;
using BookReviewer.Api.Extensions;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Models;
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
        app.MapPost("reviews", async (ReviewCreateDto reviewDto, IReviewRepository reviewRepo) =>
        {
            var newReview = new Review
            {
                Text = reviewDto.Text,
                Rating = reviewDto.Rating,
                BookId = reviewDto.BookId,
                UserId = reviewDto.UserId
            };

            var created = await reviewRepo.CreateReviewAsync(newReview);

            if (!created)
                return Results.BadRequest();
            
            return Results.Ok(newReview);
        });
        app.MapGet("/reviews", async (IReviewRepository reviewRepo) =>
        {
            var reviews = await reviewRepo.GetReviewsAsync();
            return Results.Ok(reviews.Select(r => r.AsDto()));
        });

        app.MapGet("/reviews/{id}", async (int id, IReviewRepository reviewRepo) =>
        {
            var review = await reviewRepo.GetReviewAsync(id);
            if (review is null)
                return Results.NotFound();

            return Results.Ok(review.AsDto());
        });
    }
}