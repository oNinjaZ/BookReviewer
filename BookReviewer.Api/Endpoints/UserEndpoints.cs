using BookReviewer.Api.Dtos;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Repositories;

namespace BookReviewer.Api.Endpoints;

public static class UserEndpoints
{
    public static IServiceCollection AddUserEndpoints(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static void UseUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/users", async (IUserRepository userRepo) =>
        {
            var users = await userRepo.GetUsersAsync();
            return Results.Ok(users);
        });

        app.MapGet("/users/{id}", async (int id, IUserRepository userRepo) =>
        {
            var user = await userRepo.GetUserAsync(id);
            if (user is null)
                return Results.NotFound();

            // return Results.Ok(new UserReadDto
            // {
            //     Id = user.Id,
            //     Username = user.Username,
            //     Email = user.Email
            // });
            return Results.Ok(user);
        });
    }
}