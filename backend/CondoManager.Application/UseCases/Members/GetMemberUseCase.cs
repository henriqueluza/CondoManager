using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Members;

namespace CondoManager.Application.UseCases.Members;

public class GetMemberUseCase(IMemberRepository repository)
{
    private readonly IMemberRepository _repository = repository;

    public async Task<MemberResponseDto?> Execute(Guid id)
    {
        var member = await _repository.GetById(id);

        if (member == null) return null;

        return new MemberResponseDto
        {
            Id = member.Id,
            Name = member.Name,
            Email = member.Email,
            Cpf = member.Cpf,
            DateOfBirth = member.DateOfBirth,
            Role = member.Role,
            CondominiumId = member.CondominiumId,
        };
    }
}
