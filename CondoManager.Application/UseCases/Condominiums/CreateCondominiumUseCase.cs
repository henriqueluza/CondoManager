using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Condominiums;

namespace CondoManager.Application.UseCases.Condominiums;

public class CreateCondominiumUseCase
{
    private readonly ICondominiumRepository _repository;

    public CreateCondominiumUseCase(ICondominiumRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(CreateCondominiumDto dto)
    {
        var condominium = new Condominium
        {
            Name = dto.Name,
            Address = dto.Address,
            UserId = dto.UserId,
        };
        
        await _repository.Add(condominium);
    }
}

