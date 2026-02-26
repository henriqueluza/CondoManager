using CondoManager.Domain.Entities;

namespace CondoManager.Domain.Interfaces;

public interface IMemberRepository
{
    Task<Member?> GetByID(Guid id);
    Task<ICollection<Member>> GetAll(Guid condominiumId);
    Task Add(Member member);
    Task Update(Member member);
    Task Delete(Guid id);
}

