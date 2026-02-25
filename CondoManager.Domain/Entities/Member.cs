using CondoManager.Domain.Enums;

namespace CondoManager.Domain.Entities;

public abstract class Member
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeCompleto { get; set; }
    public string Email {get; set;}
    public string Cpf {get; set;}
    public DateOnly DataNascimento {get; set;}
    public MemberRole Role {get; set;}
}