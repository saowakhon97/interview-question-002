using Example.Application.Interfaces;
using Example.Domain.Entities;
using Example.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await context.Users
            .FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}