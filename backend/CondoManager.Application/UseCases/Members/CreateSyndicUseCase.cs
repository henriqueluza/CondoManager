using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Members;

namespace CondoManager.Application.UseCases.Members;

public class CreateSyndicUseCase(IMemberRepository repository)
{
    private readonly IMemberRepository _repository = repository;

    public async Task Execute(CreateSyndicDto dto)
    {
        var syndic = new Syndic
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email,
            Cpf = dto.Cpf,
            DateOfBirth = dto.DateOfBirth,
            Role = dto.Role,
            CondominiumId = dto.CondominiumId,
            MandateStartDate = dto.MandateStartDate,
            MandateEndDate = dto.MandateEndDate,
        };

        await _repository.Add(syndic);
    }
}
