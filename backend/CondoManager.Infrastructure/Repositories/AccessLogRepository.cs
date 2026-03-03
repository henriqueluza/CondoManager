using CondoManager.Domain.Interfaces;
using CondoManager.Infrastructure.Data;
using CondoManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Infrastructure.Repositories;

public class AccessLogRepository : IAccessLogRepository
{
    private readonly CondoManagerContext _context;

    public AccessLogRepository(CondoManagerContext context)
    {
        _context = context;
    }

    public async Task<AccessLog?> GetById(Guid id)
    {
        return await _context.AccessLogs.FindAsync(id);
    }

    public async Task<ICollection<AccessLog>> GetAll(Guid CondominiumID)
    {
        return await _context.AccessLogs.Where(a => a.CondominiumId == CondominiumID).ToListAsync();
    }

    public async Task Add(AccessLog accessLog)
    {
        await _context.AccessLogs.AddAsync(accessLog);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCheckout(Guid id, DateTime TimeOfExit)
    {
        var existing = await GetById(id);
        if (existing == null) return;
        existing.TimeOfExit = TimeOfExit;
        await _context.SaveChangesAsync();
    }
}