using CondoManager.Application.DTOs.Condominiums;
using CondoManager.Application.UseCases.Condominiums;
using Microsoft.AspNetCore.Mvc;

namespace CondoManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CondominiumController : ControllerBase
{
    private readonly CreateCondominiumUseCase _createUseCase;
    private readonly GetCondominiumUseCase _getUseCase;
    private readonly UpdateCondominiumUseCase _updateUseCase;
    private readonly DeleteCondominiumUseCase _deleteUseCase;
    private readonly GetAllCondominiumsUseCase _getAllUseCase;
    
    public CondominiumController(
        CreateCondominiumUseCase createUseCase,
        GetCondominiumUseCase getUseCase,
        UpdateCondominiumUseCase updateUseCase,
        DeleteCondominiumUseCase deleteUseCase,
        GetAllCondominiumsUseCase getAllUseCase
        ) 
    {
        _createUseCase = createUseCase;
        _getUseCase = getUseCase;
        _updateUseCase = updateUseCase;
        _deleteUseCase = deleteUseCase;
        _getAllUseCase = getAllUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCondominiumDto dto)
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllUseCase.Execute();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCondominiumDto dto)
    {
        await _updateUseCase.Execute(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteUseCase.Execute(id);
        return NoContent();
    }
}