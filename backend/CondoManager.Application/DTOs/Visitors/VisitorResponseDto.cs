using CondoManager.Domain.Enums;

namespace CondoManager.Application.DTOs.Visitors;

public class VisitorResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public VisitorStatus Status { get; set; }
    public DateOnly DateOfVisit { get; set; }
    public Guid AuthorizedById { get; set; }
    public Guid CondominiumId { get; set; }
}