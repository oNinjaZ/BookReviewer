using BookReviewer.Api.Models;

namespace BookReviewer.Api.Interfaces;

public interface IUserRepository 
{
    Task<bool> CreateUserAsync(User user);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserAsync(int id);
    Task<bool> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(int id);
    Task<bool> UserExistsAsync(int id);
    Task<bool> SaveAsync();
}