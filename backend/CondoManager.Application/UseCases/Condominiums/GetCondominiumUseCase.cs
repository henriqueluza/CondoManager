using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Condominiums;

namespace CondoManager.Application.UseCases.Condominiums;

public class GetCondominiumUseCase(ICondominiumRepository repository)
{
    private readonly ICondominiumRepository _repository = repository;
   
    public async Task<CondominiumResponseDto?> Execute(Guid id)
    {
        var condominium = await _repository.GetByID(id);

        if (condominium == null) return null;
        return new CondominiumResponseDto
        {
            Id = condominium.Id,
            Name = condominium.Name,
            CreatedAt = condominium.CreatedAt,
            Address = condominium.Address,
            UserId = condominium.UserId,
        };
    }
    
}