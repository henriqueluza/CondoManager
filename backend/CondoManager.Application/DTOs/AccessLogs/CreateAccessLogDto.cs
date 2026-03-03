namespace CondoManager.Application.DTOs.AccessLogs;

public class CreateAccessLogDto
{
    public Guid VisitorId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid CondominiumId { get; set; }
}