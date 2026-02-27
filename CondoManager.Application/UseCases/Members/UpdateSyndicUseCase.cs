using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Members;

namespace CondoManager.Application.UseCases.Members;

public class UpdateSyndicUseCase(IMemberRepository repository)
{
    private readonly IMemberRepository _repository = repository;

    public async Task Execute(Guid id, UpdateSyndicDto dto)
    {
        var member = await _repository.GetById(id);

        if (member is not Syndic syndic) return;

        syndic.Name = dto.Name;
        syndic.Email = dto.Email;
        syndic.Cpf = dto.Cpf;
        syndic.DateOfBirth = dto.DateOfBirth;
        syndic.Role = dto.Role;
        syndic.MandateStartDate = dto.MandateStartDate;
        syndic.MandateEndDate = dto.MandateEndDate;

        await _repository.Update(syndic);
    }
}
