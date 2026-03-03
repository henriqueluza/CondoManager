using CondoManager.Domain.Interfaces;

namespace CondoManager.Application.UseCases.Employees;

public class DeleteEmployeeUseCase(IEmployeeRepository repository)
{
    private readonly IEmployeeRepository _repository = repository;

    public async Task Execute(Guid id)
    {
        await _repository.Delete(id);
    }
}
