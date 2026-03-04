using CondoManager.Domain.Enums;

namespace CondoManager.Application.DTOs.Employees;

public class EmployeeResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public EmployeeRole Role { get; set; }
    public Guid CondominiumId { get; set; }
}
