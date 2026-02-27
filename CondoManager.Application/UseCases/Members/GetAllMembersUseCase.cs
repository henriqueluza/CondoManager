using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Members;

namespace CondoManager.Application.UseCases.Members;

public class GetAllMembersUseCase(IMemberRepository repository)
{
    private readonly IMemberRepository _repository = repository;

    public async Task<ICollection<MemberResponseDto>> Execute(Guid condominiumId)
    {
        var members = await _repository.GetAll(condominiumId);

        return members.Select(m => new MemberResponseDto
        {
            Id = m.Id,
            Name = m.Name,
            Email = m.Email,
            Cpf = m.Cpf,
            DateOfBirth = m.DateOfBirth,
            Role = m.Role,
            CondominiumId = m.CondominiumId,
        }).ToList();
    }
}
