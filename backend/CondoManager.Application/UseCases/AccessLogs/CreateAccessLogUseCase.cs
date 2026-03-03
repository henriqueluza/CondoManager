using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.AccessLogs;

namespace CondoManager.Application.UseCases.AccessLogs;

public class CreateAccessLogUseCase(IAccessLogRepository repository)
{
    private readonly IAccessLogRepository _repository = repository;

    public async Task Execute(CreateAccessLogDto dto)
    {
        var accessLog = new AccessLog()
        {
            VisitorId = dto.VisitorId,
            EmployeeId = dto.EmployeeId,
            TimeOfEntry = DateTime.UtcNow,
            CondominiumId = dto.CondominiumId
        };
        await _repository.Add(accessLog);
    }
}
