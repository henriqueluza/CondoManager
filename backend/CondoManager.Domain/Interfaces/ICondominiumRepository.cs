using CondoManager.Domain.Entities;

namespace CondoManager.Domain.Interfaces;

public interface ICondominiumRepository
{
    Task<Condominium?> GetByID(Guid id);
    Task <ICollection<Condominium>> GetAll();
    Task Add(Condominium condominium);
    Task Update(Condominium condominium);   
    Task Delete(Guid id);
}