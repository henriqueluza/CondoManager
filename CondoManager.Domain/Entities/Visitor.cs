using CondoManager.Domain.Enums;

namespace CondoManager.Domain.Entities;

public class Visitor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string CPF { get; set; }
    public VisitorStatus Status { get; set; }
    public DateOnly DateOfVisit { get; set; }
    public Guid AuthorizedById { get; set; }
    public Resident AuthorizedBy { get; set; }
}