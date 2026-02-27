using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Condominiums;

namespace CondoManager.Application.UseCases.Condominiums;

public class GetAllCondominiumUseCase(ICondominiumRepository repository)
{
    private readonly ICondominiumRepository _repository = repository;
   
    public async Task<ICollection<CondominiumResponseDto>> Execute()
    {
        var condominiums = await _repository.GetAll();

        return condominiums.Select(c => new CondominiumResponseDto
        {
            Id = c.Id,
            Name = c.Name,
            CreatedAt = c.CreatedAt,
            Address = c.Address,
            UserId = c.UserId,
        }).ToList();
    }
    
}