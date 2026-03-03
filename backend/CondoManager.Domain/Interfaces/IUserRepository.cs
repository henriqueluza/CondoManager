using CondoManager.Domain.Entities;

namespace CondoManager.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetById(Guid id);
    Task<User?> GetByEmail(string email);
    Task Add(User user);
    Task Update(User user);
    Task Delete(Guid id);
}