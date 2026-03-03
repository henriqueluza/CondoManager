using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Visitors;

namespace CondoManager.Application.UseCases.Visitors;

public class GetAllVisitorsUseCase(IVisitorRepository repository)
{
    private readonly IVisitorRepository _repository = repository;

    public async Task<ICollection<VisitorResponseDto>> Execute(Guid condominiumId)
    {
        var visitors = await _repository.GetAll(condominiumId);

        return visitors.Select(v => new VisitorResponseDto
        {
            Id = v.Id,
            Name = v.Name,
            CPF = v.CPF,
            Status = v.Status,
            DateOfVisit = v.DateOfVisit,
            AuthorizedById = v.AuthorizedById,
            CondominiumId = v.CondominiumId,
        }).ToList();
    }
}