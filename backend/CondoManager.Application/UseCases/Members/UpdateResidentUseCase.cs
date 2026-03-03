using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Members;

namespace CondoManager.Application.UseCases.Members;

public class UpdateResidentUseCase(IMemberRepository repository)
{
    private readonly IMemberRepository _repository = repository;

    public async Task Execute(Guid id, UpdateResidentDto dto)
    {
        var member = await _repository.GetById(id);

        if (member is not Resident resident) return;

        resident.Name = dto.Name;
        resident.Email = dto.Email;
        resident.Cpf = dto.Cpf;
        resident.DateOfBirth = dto.DateOfBirth;
        resident.Role = dto.Role;
        resident.Apartment = dto.Apartment;
        resident.Block = dto.Block;

        await _repository.Update(resident);
    }
}
