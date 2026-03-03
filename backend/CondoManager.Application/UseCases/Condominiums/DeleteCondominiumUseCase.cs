using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Condominiums;

namespace CondoManager.Application.UseCases.Condominiums;

public class DeleteCondominiumUseCase(ICondominiumRepository repository)
{
    private readonly ICondominiumRepository _repository = repository;
    public async Task Execute(Guid id)
    {
        await _repository.Delete(id);
    }
    
}