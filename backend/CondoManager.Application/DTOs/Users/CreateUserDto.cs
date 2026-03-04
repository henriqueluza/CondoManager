namespace CondoManager.Application.DTOs.Users;

public class CreateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Cellphone { get; set; }
    public string Password { get; set; }
}