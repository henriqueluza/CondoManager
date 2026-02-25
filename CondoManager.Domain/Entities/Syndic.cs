namespace CondoManager.Domain.Entities;

public class Syndic: Member
{
    public DateOnly MandateStartDate { get; set; }
    public DateOnly MandateEndDate { get; set; } 
}