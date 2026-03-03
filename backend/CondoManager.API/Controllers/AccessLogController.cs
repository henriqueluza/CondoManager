using CondoManager.Application.DTOs.AccessLogs;
using CondoManager.Application.UseCases.AccessLogs;
using Microsoft.AspNetCore.Mvc;

namespace CondoManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AccessLogController : ControllerBase
{
    private readonly CreateAccessLogUseCase _createUseCase;
    private readonly GetAccessLogUseCase _getUseCase;
    private readonly GetAllAccessLogsUseCase _getAllUseCase;
    private readonly UpdateAccessLogCheckoutUseCase _updateUseCase;
    
    public AccessLogController(
        CreateAccessLogUseCase createUseCase,
        GetAccessLogUseCase getUseCase,
        GetAllAccessLogsUseCase getAllUseCase,
        UpdateAccessLogCheckoutUseCase updateUseCase
        )
        
        {
        _createUseCase = createUseCase;
        _getUseCase = getUseCase;
        _getAllUseCase = getAllUseCase;
        _updateUseCase = updateUseCase;
        }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccessLogDto dto)
    {
        await _createUseCase.Execute(dto);
        return Created();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result =  await _getUseCase.Execute(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("condominiums/{condominiumId}")]
    public async Task<IActionResult> GetAll(Guid condominiumId)
    {
        var result = await _getAllUseCase.Execute(condominiumId);
        return Ok(result);
    }

    [HttpPatch("{id}/checkout")]
    public async Task<IActionResult> Checkout(Guid id)
    {
        await _updateUseCase.Execute(id);
        return NoContent();
    }
}