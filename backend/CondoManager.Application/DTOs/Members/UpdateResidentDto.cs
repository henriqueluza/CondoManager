using CondoManager.Domain.Enums;

namespace CondoManager.Application.DTOs.Members;

public class UpdateResidentDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public MemberRole Role { get; set; }
    public string Apartment { get; set; }
    public string Block { get; set; }
}
