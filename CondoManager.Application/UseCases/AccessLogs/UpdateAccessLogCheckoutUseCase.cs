using CondoManager.Domain.Interfaces;

namespace CondoManager.Application.UseCases.AccessLogs;
public class UpdateAccessLogCheckoutUseCase(IAccessLogRepository repository)
{
    private readonly IAccessLogRepository _repository = repository;

    public async Task Execute(Guid id)
    {
        var accessLog = await _repository.GetById(id);
        
        if (accessLog == null) return;
        
        await _repository.UpdateCheckout(id, DateTime.UtcNow);

    }
}