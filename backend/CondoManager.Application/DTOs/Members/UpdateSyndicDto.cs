using CondoManager.Domain.Enums;

namespace CondoManager.Application.DTOs.Members;

public class UpdateSyndicDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public MemberRole Role { get; set; }
    public DateOnly MandateStartDate { get; set; }
    public DateOnly MandateEndDate { get; set; }
}
