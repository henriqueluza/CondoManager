namespace CondoManager.Application.DTOs.Condominiums;

public class CreateCondominiumDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public Guid UserId { get; set; }
}