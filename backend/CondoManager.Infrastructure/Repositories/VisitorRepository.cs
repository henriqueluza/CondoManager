using CondoManager.Domain.Interfaces;
using CondoManager.Infrastructure.Data;
using CondoManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Infrastructure.Repositories;

public class VisitorRepository : IVisitorRepository
{
    private readonly CondoManagerContext _context;

    public VisitorRepository(CondoManagerContext context)
    {
        _context = context;
    }

    public async Task<Visitor?> GetById(Guid id)
    {
        return await _context.Visitors.FindAsync(id);
    }

    public async Task<ICollection<Visitor>> GetAll(Guid condominiumId)
    {
        return await _context.Visitors.Where(v => v.CondominiumId == condominiumId).ToListAsync();
    }

    public async Task Add(Visitor visitor)
    {
        await _context.Visitors.AddAsync(visitor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStatus(Visitor visitor)
    {
        var existing = await GetById(visitor.Id);
        if (existing == null) return;
        _context.Visitors.Update(visitor);
        await _context.SaveChangesAsync();
    }
}