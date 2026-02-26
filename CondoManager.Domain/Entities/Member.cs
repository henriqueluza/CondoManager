using CondoManager.Domain.Enums;

namespace CondoManager.Domain.Entities;

public abstract class Member
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email {get; set;}
    public string Cpf {get; set;}
    public DateOnly DateOfBirth {get; set;}
    public MemberRole Role {get; set;}
    public Guid CondominiumId { get; set; }
    public Condominium Condominium { get; set; }
}