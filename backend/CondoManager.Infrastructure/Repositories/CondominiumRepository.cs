using CondoManager.Domain.Interfaces;
using CondoManager.Infrastructure.Data;
using CondoManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Infrastructure.Repositories;

public class CondominiumRepository : ICondominiumRepository
{
    private readonly CondoManagerContext _context;
    public CondominiumRepository(CondoManagerContext context)
    {
        _context = context;
    }

    public async Task<Condominium?> GetByID(Guid id)
    {
        return  await _context.Condominiums.FindAsync(id);
    }

    public async Task<ICollection<Condominium>> GetAll()
    {
        return await _context.Condominiums.ToListAsync();
    }
    
    public async Task Add(Condominium condominium)
    {
        await _context.Condominiums.AddAsync(condominium);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Condominium condominium)
    {   
        var existing = await GetByID(condominium.Id);
        if (existing == null) return;
        _context.Condominiums.Update(condominium);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var condominium = await GetByID(id);
        if (condominium == null) return;
        _context.Condominiums.Remove(condominium);
        await _context.SaveChangesAsync();
    }
}