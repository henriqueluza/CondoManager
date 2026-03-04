using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Employees;

namespace CondoManager.Application.UseCases.Employees;

public class UpdateEmployeeUseCase(IEmployeeRepository repository)
{
    private readonly IEmployeeRepository _repository = repository;

    public async Task Execute(Guid id, UpdateEmployeeDto dto)
    {
        var employee = await _repository.GetById(id);

        if (employee == null) return;

        employee.Name = dto.Name;
        employee.Email = dto.Email;
        employee.Cpf = dto.Cpf;
        employee.DateOfBirth = dto.DateOfBirth;
        employee.Role = dto.Role;

        await _repository.Update(employee);
    }
}
