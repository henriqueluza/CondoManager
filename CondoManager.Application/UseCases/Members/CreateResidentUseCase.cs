using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Members;

namespace CondoManager.Application.UseCases.Members;

public class CreateResidentUseCase(IMemberRepository repository)
{
    private readonly IMemberRepository _repository = repository;

    public async Task Execute(CreateResidentDto dto)
    {
        var resident = new Resident
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email,
            Cpf = dto.Cpf,
            DateOfBirth = dto.DateOfBirth,
            Role = dto.Role,
            CondominiumId = dto.CondominiumId,
            Apartment = dto.Apartment,
            Block = dto.Block,
        };

        await _repository.Add(resident);
    }
}
