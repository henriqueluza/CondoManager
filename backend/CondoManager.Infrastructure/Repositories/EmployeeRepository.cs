using CondoManager.Domain.Interfaces;
using CondoManager.Infrastructure.Data;
using CondoManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoManager.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly CondoManagerContext _context;
    
    public EmployeeRepository(CondoManagerContext context)
    {
        _context = context;
    }
    public async Task<Employee?> GetById(Guid id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<ICollection<Employee>> GetAll(Guid condominiumId)
    {
        return await _context.Employees.Where(m => m.CondominiumId == condominiumId).ToListAsync();
    }

    public async Task Add(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Employee employee)
    {   
        var existing = await GetById(employee.Id);
        if (existing == null) return;
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var employee = await GetById(id);
        if (employee == null) return;
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
}
