using CondoManager.Domain.Enums;

namespace CondoManager.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public EmployeeRole Role { get; set; }
    public string Shift { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid CondominiumId { get; set; }
    public Condominium Condominium { get; set; }
}
