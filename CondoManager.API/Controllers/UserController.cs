using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CondoManager.Application.DTOs.Users;
using CondoManager.Application.UseCases.Users;

namespace CondoManager.API.Controllers;

[ApiController ]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly CreateUserUseCase _createUseCase;
    private readonly GetUserUseCase _getUseCase;
    private readonly LoginUserUseCase _loginUseCase;
    
    public UserController(
        CreateUserUseCase createUseCase,
        GetUserUseCase getUseCase,
        LoginUserUseCase loginUseCase)

    {
        _createUseCase = createUseCase;
        _getUseCase = getUseCase;
        _loginUseCase = loginUseCase;
    }

    [AllowAnonymous]
    [HttpPost("register")]

    public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
    {
        await _createUseCase.Execute(dto);
        return Created();
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getUseCase.Execute(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("login")]

    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        var token = await _loginUseCase.Execute(dto);
        if (token == null) return Unauthorized();
    
        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(7)
        });
    
        return Ok();
    }
}