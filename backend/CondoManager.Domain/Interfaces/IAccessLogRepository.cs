using CondoManager.Domain.Entities;

namespace CondoManager.Domain.Interfaces;

public interface IAccessLogRepository
{
    Task<AccessLog?> GetById(Guid id);
    Task<ICollection<AccessLog>> GetAll(Guid CondominiumID);
    Task Add(AccessLog accessLog);
    Task UpdateCheckout(Guid id, DateTime TimeOfExit);
}