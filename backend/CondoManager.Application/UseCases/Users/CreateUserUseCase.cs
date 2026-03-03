using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Users;

namespace CondoManager.Application.UseCases.Users;

public class CreateUserUseCase(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;

    public async Task Execute(CreateUserDto dto)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Cpf = dto.Cpf,
            Cellphone = dto.Cellphone,
            PasswordHash = passwordHash,
        };
        
        await _repository.Add(user);
    }
}