using CondoManager.Domain.Entities; 

namespace CondoManager.Domain.Interfaces;

public interface IVisitorRepository
{
    Task<Visitor?> GetById(Guid id);
    Task<ICollection<Visitor>> GetAll(Guid CondominiumId);
    Task Add(Visitor visitor);
    Task UpdateStatus(Visitor visitor);
    
}

