using CondoManager.Domain.Interfaces;
using CondoManager.Infrastructure.Data;
using CondoManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly CondoManagerContext _context;
    
    public MemberRepository(CondoManagerContext context)
    {
        _context = context;
    }

    public async Task<Member?> GetById(Guid id)
    {
        return await _context.Members.FindAsync(id);
    }

    public async Task<ICollection<Member>> GetAll(Guid condominiumId)
    {
        return await _context.Members.Where(m => m.CondominiumId == condominiumId).ToListAsync();
    }

    public async Task Add(Member member)
    {
        await _context.Members.AddAsync(member);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Member member)
    {   
        var existing = await GetById(member.Id);
        if (existing == null) return;
        _context.Members.Update(member);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var member = await GetById(id);
        if (member == null) return;
        _context.Members.Remove(member);
        await _context.SaveChangesAsync();
    }
}