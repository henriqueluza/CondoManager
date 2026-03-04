using CondoManager.Domain.Entities;

namespace CondoManager.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee?> GetById(Guid id);
    Task<ICollection<Employee>> GetAll(Guid condominiumId);
    Task Add(Employee employee);
    Task Update(Employee employee);
    Task Delete(Guid id);
}