using CondoManager.Infrastructure.Data;
using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CondoManagerContext _context;
    
    public UserRepository(CondoManagerContext context)
    {
        _context = context;
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        var existing = await GetById(user.Id);
        if (existing == null) return;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var user = await GetById(id);
        if (user == null) return;
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}