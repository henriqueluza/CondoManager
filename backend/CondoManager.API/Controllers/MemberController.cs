using CondoManager.Application.DTOs.Members;
using CondoManager.Application.UseCases.Employees;
using CondoManager.Application.UseCases.Members;
using Microsoft.AspNetCore.Mvc;

namespace CondoManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MemberController : ControllerBase
{
    private readonly CreateResidentUseCase _createResidentUseCase;
    private readonly CreateSyndicUseCase _createSyndicUseCase;
    private readonly DeleteMemberUseCase _deleteUseCase;
    private readonly GetMemberUseCase _getUseCase;
    private readonly GetAllMembersUseCase _getAllUseCase;
    private readonly UpdateResidentUseCase _updateResidentUseCase;
    private readonly UpdateSyndicUseCase _updateSyndicUseCase;

    public MemberController(
        CreateResidentUseCase createResidentUseCase,
        CreateSyndicUseCase createSyndicUseCase,
        DeleteMemberUseCase deleteUseCase,
        GetMemberUseCase getUseCase,
        GetAllMembersUseCase getAllUseCase,
        UpdateResidentUseCase updateResidentUseCase,
        UpdateSyndicUseCase updateSyndicUseCase
    )
    {
        _createResidentUseCase = createResidentUseCase;
        _createSyndicUseCase = createSyndicUseCase;
        _deleteUseCase = deleteUseCase;
        _getUseCase = getUseCase;
        _getAllUseCase = getAllUseCase;
        _updateResidentUseCase = updateResidentUseCase;
        _updateSyndicUseCase = updateSyndicUseCase;
    }

    [HttpPost("resident")]
    public async Task<IActionResult> CreateResident([FromBody] CreateResidentDto dto)
    {
        await _createResidentUseCase.Execute(dto);
        return Created();
    }

    [HttpPost("syndic")]
    public async Task<IActionResult> CreateSyndic([FromBody] CreateSyndicDto dto)
    {
        await _createSyndicUseCase.Execute(dto);
        return Created();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getUseCase.Execute(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("condominium/{condominiumId}")]
    public async Task<IActionResult> GetAll(Guid condominiumId)
    {
        var result = await _getAllUseCase.Execute(condominiumId);
        return Ok(result);
    }

    [HttpPut("resident/{id}")]
    public async Task<IActionResult> UpdateResident(Guid id, [FromBody] UpdateResidentDto dto)
    {
        await _updateResidentUseCase.Execute(id, dto);
        return NoContent();
    }

    [HttpPut("syndic/{id}")]
    public async Task<IActionResult> UpdateSyndic(Guid id, [FromBody] UpdateSyndicDto dto)
    {
        await _updateSyndicUseCase.Execute(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteUseCase.Execute(id);
        return NoContent();
    }
}