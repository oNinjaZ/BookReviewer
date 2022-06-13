using BookReviewer.Api.Data;
using BookReviewer.Api.Interfaces;
using BookReviewer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateUserAsync(User user)
    {
        await _context.User.AddAsync(user);
        return await SaveAsync();
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        _context.Update(user);
        return await SaveAsync();
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await GetUserAsync(id);
        if (user is null)
            return false;

        _context.User.Remove(user);
        return await SaveAsync();
    }

    public async Task<bool> UserExistsAsync(int id) => await _context.User.AnyAsync(u => u.Id == id);

    public async Task<bool> SaveAsync()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }


}