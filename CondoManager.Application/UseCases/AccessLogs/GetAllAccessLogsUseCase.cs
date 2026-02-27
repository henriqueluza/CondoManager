using CondoManager.Domain.Entities;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.DTOs.AccessLogs;

namespace CondoManager.Application.UseCases.AccessLogs;

public class GetAllAccessLogsUseCase(IAccessLogRepository repository)
{
    private readonly IAccessLogRepository _repository = repository;
   
    public async Task<ICollection<AccessLogResponseDto>> Execute(Guid condominiumId)
    {
        var accessLogs = await _repository.GetAll(condominiumId);

        return accessLogs.Select(a => new AccessLogResponseDto
        {
            Id = a.Id,
            VisitorId = a.VisitorId,
            TimeOfEntry = a.TimeOfEntry,
            TimeOfExit = a.TimeOfExit,
            EmployeeId = a.EmployeeId,
            CondominiumId = a.CondominiumId,
        }).ToList();
    }
    
}