namespace CondoManager.Application.DTOs.Visitors;

public class CreateVisitorDto
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public DateOnly DateOfVisit { get; set; }
    public Guid AuthorizedById { get; set; }
    public Guid CondominiumId { get; set; }
}