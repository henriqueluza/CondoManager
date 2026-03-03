namespace CondoManager.Application.DTOs.Condominiums;

public class CondominiumResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

}