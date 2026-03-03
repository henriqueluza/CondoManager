namespace CondoManager.Application.DTOs.AccessLogs;

public class AccessLogResponseDto
{
    public Guid Id { get; set; }
    
    public Guid VisitorId { get; set; }
    
    public Guid EmployeeId { get; set; }
    
    public DateTime TimeOfEntry { get; set; }
    public DateTime? TimeOfExit { get; set; }
    
    public Guid CondominiumId { get; set; }
}