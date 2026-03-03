using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.AccessLogs;
using CondoManager.Domain.Entities;

namespace CondoManager.Application.UseCases.AccessLogs;

public class GetAccessLogUseCase(IAccessLogRepository repository)
{
    private readonly IAccessLogRepository _repository = repository;

    public async Task<AccessLogResponseDto?> Execute(Guid id)
    {
        var accessLog = await _repository.GetById(id);
        if (accessLog == null) return null;

        return new AccessLogResponseDto
        {
            Id = accessLog.Id,
            VisitorId = accessLog.VisitorId,
            CondominiumId = accessLog.CondominiumId,
            EmployeeId = accessLog.EmployeeId,
            TimeOfExit = accessLog.TimeOfExit,
            TimeOfEntry = accessLog.TimeOfEntry,

        };
    }
}