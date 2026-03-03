using CondoManager.Application.DTOs.Employees;
using CondoManager.Application.UseCases.Employees;
using Microsoft.AspNetCore.Mvc;

namespace CondoManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly CreateEmployeeUseCase _createUseCase;
    private readonly DeleteEmployeeUseCase _deleteUseCase;
    private readonly GetEmployeeUseCase _getUseCase;
    private readonly GetAllEmployeesUseCase _getAllUseCase;
    private readonly UpdateEmployeeUseCase _updateUseCase;

    public EmployeeController(
        CreateEmployeeUseCase createUseCase,
        DeleteEmployeeUseCase deleteUseCase,
        GetEmployeeUseCase getUseCase,
        GetAllEmployeesUseCase getAllUseCase,
        UpdateEmployeeUseCase updateUseCase)
    {
        _createUseCase = createUseCase;
        _deleteUseCase = deleteUseCase;
        _getUseCase = getUseCase;
        _getAllUseCase = getAllUseCase;
        _updateUseCase = updateUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
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

    [HttpGet("condominiums/{condominiumId}")]

    public async Task<IActionResult> GetAll(Guid condominiumId)
    {
        var result = await _getAllUseCase.Execute(condominiumId);
        return Ok(result);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteUseCase.Execute(id);
        return NoContent();
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeDto dto)
    {
        await _updateUseCase.Execute(id, dto);
        return NoContent();
    }
}