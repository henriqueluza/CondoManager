using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Condominiums;

namespace CondoManager.Application.UseCases.Condominiums;

public class UpdateCondominiumUseCase(ICondominiumRepository repository)
{
    private readonly ICondominiumRepository _repository = repository;
    public async Task Execute(Guid id, UpdateCondominiumDto dto)
    {
        var condominium = await _repository.GetByID(id);

        if (condominium == null) return;
        
        condominium.Name = dto.Name;
        condominium.Address = dto.Address;
        
        await _repository.Update(condominium);
    }
    
}