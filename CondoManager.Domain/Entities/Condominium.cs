using CondoManager.Domain.Enums;

namespace CondoManager.Domain.Entities;

public class Condominium
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
   public ICollection<Member> Members { get; set; } = new List<Member>();
}