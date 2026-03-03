namespace CondoManager.Domain.Entities;

public class AccessLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid VisitorId { get; set; }
    public Visitor Visitor { get; set; }
    
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    public DateTime TimeOfEntry { get; set; }
    public DateTime? TimeOfExit { get; set; }
    
    public Guid CondominiumId { get; set; }
    public Condominium Condominium { get; set; }
}