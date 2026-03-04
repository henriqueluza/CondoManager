using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CondoManager.Application.UseCases.Users;

public class LoginUserUseCase(IUserRepository repository)
{
    private readonly IUserRepository _repository =  repository;

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("sua-chave-secreta-deve-ter-32-caracteres!!");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<string?> Execute(LoginUserDto dto)
    {
        var user = await _repository.GetByEmail(dto.Email); 
        
        if (user == null) return null;

        var senhaCorreta = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
        if (!senhaCorreta) return null;
        
        return GenerateToken(user);
    }
}