using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Users;

namespace CondoManager.Application.UseCases.Users;

public class GetUserUseCase(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task<UserResponseDto?> Execute(Guid id)
    {
        var user = await _repository.GetById(id);
        
        if (user == null) return null;
        return new UserResponseDto
        {
            Name = user.Name,
            Email = user.Email,
            Cpf = user.Cpf,
            Cellphone = user.Cellphone
        };
    }
}