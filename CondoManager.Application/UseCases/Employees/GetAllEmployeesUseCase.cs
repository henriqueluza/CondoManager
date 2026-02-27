using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.Employees;

namespace CondoManager.Application.UseCases.Employees;

public class GetAllEmployeesUseCase(IEmployeeRepository repository)
{
    private readonly IEmployeeRepository _repository = repository;

    public async Task<ICollection<EmployeeResponseDto>> Execute(Guid condominiumId)
    {
        var employees = await _repository.GetAll(condominiumId);

        return employees.Select(e => new EmployeeResponseDto
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email,
            Cpf = e.Cpf,
            DateOfBirth = e.DateOfBirth,
            Role = e.Role,
            CondominiumId = e.CondominiumId,
        }).ToList();
    }
}
