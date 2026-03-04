using CondoManager.Domain.Interfaces;

namespace CondoManager.Application.UseCases.Members;

public class DeleteMemberUseCase(IMemberRepository repository)
{
    private readonly IMemberRepository _repository = repository;

    public async Task Execute(Guid id)
    {
        await _repository.Delete(id);
    }
}
