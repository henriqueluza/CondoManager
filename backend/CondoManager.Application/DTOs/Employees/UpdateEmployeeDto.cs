using CondoManager.Domain.Enums;

namespace CondoManager.Application.DTOs.Employees;

public class UpdateEmployeeDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public EmployeeRole Role { get; set; }
}
