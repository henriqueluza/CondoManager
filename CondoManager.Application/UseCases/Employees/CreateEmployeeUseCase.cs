using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Employees;

namespace CondoManager.Application.UseCases.Employees;

public class CreateEmployeeUseCase(IEmployeeRepository repository)
{
    private readonly IEmployeeRepository _repository = repository;

    public async Task Execute(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email,
            Cpf = dto.Cpf,
            DateOfBirth = dto.DateOfBirth,
            Role = dto.Role,
            CondominiumId = dto.CondominiumId,
        };

        await _repository.Add(employee);
    }
}
