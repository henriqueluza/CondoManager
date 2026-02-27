using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Domain.Enums;
using CondoManager.Application.DTOs.Visitors;

namespace CondoManager.Application.UseCases.Visitors;

public class CreateVisitorUseCase(IVisitorRepository repository)
{
    private readonly IVisitorRepository _repository = repository;

    public async Task Execute(CreateVisitorDto dto)
    {
        var visitor = new Visitor
        {
            Name = dto.Name,
            CPF = dto.CPF,
            DateOfVisit = dto.DateOfVisit,
            AuthorizedById = dto.AuthorizedById,
            CondominiumId = dto.CondominiumId,
            Status = VisitorStatus.Pending
        };

        await _repository.Add(visitor);
    }
}