namespace CondoManager.Domain.Entities;

public class Resident : Member
{
    public string Apartment { get; set; }
    public string Block { get; set; }
}