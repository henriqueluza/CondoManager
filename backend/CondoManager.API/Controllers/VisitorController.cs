using CondoManager.Application.DTOs.Visitors;
using CondoManager.Application.UseCases.Visitors;
using Microsoft.AspNetCore.Mvc;

namespace CondoManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class VisitorController : ControllerBase
{
    private readonly CreateVisitorUseCase _createUseCase;
    private readonly GetAllVisitorsUseCase _getAllUseCase;

    public VisitorController(CreateVisitorUseCase createUseCase, GetAllVisitorsUseCase getAllUseCase)
    {
        _createUseCase = createUseCase;
        _getAllUseCase = getAllUseCase;
    }

    [HttpPost]

    public async Task<IActionResult> Create([FromBody] CreateVisitorDto dto)
    {
        await _createUseCase.Execute(dto);
        return Created();
    }

    [HttpGet("condominium/{condominiumId}")]
    public async Task<IActionResult> GetAll(Guid condominiumId)
    {
        var result = await _getAllUseCase.Execute(condominiumId);
        return Ok(result);
    }
}