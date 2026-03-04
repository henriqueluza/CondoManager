using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Employees;

namespace CondoManager.Application.UseCases.Employees;

public class GetEmployeeUseCase(IEmployeeRepository repository)
{
    private readonly IEmployeeRepository _repository = repository;

    public async Task<EmployeeResponseDto?> Execute(Guid id)
    {
        var employee = await _repository.GetById(id);

        if (employee == null) return null;

        return new EmployeeResponseDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Cpf = employee.Cpf,
            DateOfBirth = employee.DateOfBirth,
            Role = employee.Role,
            CondominiumId = employee.CondominiumId,
        };
    }
}
